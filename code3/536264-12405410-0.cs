    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading;
    using Foo.Applications.PersistenceTools;
    using Foo.Data.Query;
    
    namespace Foo.DataHelpers
    {
      /// <summary>
      /// Used for passing data to a new thread.
      /// </summary>
      internal class DataLoadRequest
      {
        public int Skip { get; private set; }
        public int Take { get; private set; }
    
        public DataLoadRequest(int skip, int take)
        {
          Skip = skip;
          Take = take;
        }
      }
      /// <summary>
      /// This class allows for lazy loading of an arbitrary range of data. 
      /// </summary>
      /// <typeparam name="S">The entity type which should be queried.</typeparam>
      public class LazyDataLoader<S> where S : class
      {
        private S[] _cachedData;
        private readonly int _defaultChunkSize;
        private readonly Expression<Func<S, bool>> _whereClause;
        private readonly IApplicationDataSession _dataSession;
    
    
        private ManualResetEvent _donePreloadingDataEvent;
    
        private int? _totalRecords;
    
        public LazyDataLoader(Expression<Func<S, bool>> whereClause, IApplicationDataSession dataSession, int defaultChunkSize = 30, int? totalRecords = null)
        {
          _defaultChunkSize = defaultChunkSize;
          _whereClause = whereClause;
          _dataSession = dataSession;
    
          _totalRecords = totalRecords;
        }
    
        /// <summary>
        /// The total number of items that exist either in memory or in the DB.
        /// </summary>
        /// <returns></returns>
        public int TotalItems()
        {
          return CachedData.Length;
        }
    
        /// <summary>
        /// Get a subset of the items.  
        /// </summary>
        /// <param name="index">the index from which to start</param>
        /// <param name="take">the number of items to pull out.</param>
        /// <returns></returns>
        public S[] GetRange(int index, int take)
        {
          //don't start preloading new data until the previous data has been preloaded.
          if (_donePreloadingDataEvent != null)
          {
            _donePreloadingDataEvent.WaitOne();
          }
    
          if (index > TotalItems())
          {
            throw new ArgumentException(string.Format("Index of: {0} was greater than total items: {1}", index, TotalItems()));
          }
    
          if (take == 0)
          {
            return new S[0];
          }
          else if (take < 0)
          {
            throw new ArgumentException(string.Format("For index {0}, take had a value of {1}.", index, take));
          }
    
          // if we're at the end of the data set, don't pick a range that's out of bounds.
          var numberToTake = Math.Min(take, TotalItems() - index);
          var range = CachedData.ToList().GetRange(index, numberToTake);
    
          //if all values are already cached, return them
          var firstDefaultIndex = range.FindIndex(s => s == default(S));
          if (firstDefaultIndex == -1)
          {
            return range.ToArray();
          }
    
          LoadAsNeeded(range, index);
    
    
          return range.ToArray();
        }
    
        /// <summary>
        /// This can be called to prepare a range of data prior to usage.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="take"></param>
        public void PreloadRangeAsync(int index, int take)
        {
          if (index >= TotalItems())
          {
            return;
          }
    
          //don't start preloading new data until the previous data has been preloaded.
          if (_donePreloadingDataEvent != null)
          {
            _donePreloadingDataEvent.WaitOne();
          }
    
          // if we're at the end of the data set, don't pick a range that's out of bounds.
          var numberToTake = Math.Min(take, TotalItems() - index);
          var range = CachedData.ToList().GetRange(index, numberToTake);
    
          //if all values are already cached, return them
          var firstDefaultIndex = range.FindIndex(s => s == default(S));
          if (firstDefaultIndex == -1)
          {
            return;
          }
    
          _donePreloadingDataEvent = new ManualResetEvent(false);
    
          ThreadPool.QueueUserWorkItem(AsyncDataLoadingHandler, new DataLoadRequest(index, numberToTake));
        }
    
        /// <summary>
        /// The number of items currently in memory
        /// </summary>
        /// <returns></returns>
        public int TotalCachedItems()
        {
          return CachedData.Count(cd => cd != default(S));
        }
    
        private void AsyncDataLoadingHandler(object state)
        {
          try
          {
            var dataLoadRequest = (DataLoadRequest)state;
            var results = Load(dataLoadRequest.Skip, dataLoadRequest.Take);
            AddData(results, dataLoadRequest.Skip);
          }
          finally
          {
            _donePreloadingDataEvent.Set();
          }
        }
    
        private void AddData(S[] dataToAdd, int startingIndex)
        {
          if (dataToAdd.Length + startingIndex > _totalRecords)
          {
            throw new Exception("Error when loading new data into array.  The index would be out of bounds.");
          }
    
          lock (CachedData)
          {
            dataToAdd.CopyTo(CachedData, startingIndex);
          }
        }
    
        private S[] Load(int skip, int take)
        {
          var pageInfo = new PageInfo(skip, take);
          var queryData = new QueryData<S>(_whereClause, pageInfo: pageInfo, includeChildren: true);
          var results = _dataSession.Query(queryData);
    
          _totalRecords = _totalRecords ?? results.TotalRecords;
    
          return results.Results.ToArray();
        }
    
        private void LoadAsNeeded(List<S> range, int startingIndex)
        {
          var firstDefaultIndex = range.FindIndex(s => s == default(S));
          if (firstDefaultIndex == -1)
          {
            return;
          }
    
          var i = firstDefaultIndex;
          while (i < range.Count)
          {
            // continue looping through items until you hit a default
            if (range[i] == default(S))
            {
              var numSequentialDefaults = GetLengthOfSequentialDefaults(range.GetRange(i, range.Count - i));
              var newValues = Load(i + startingIndex, numSequentialDefaults);
    
              //loop through the new values and assign them where necessary
              var j = 0;
              while (j < newValues.Length)
              {
                range[j + i] = newValues[j];
                CachedData[startingIndex + j + i] = newValues[j];
                j++;
              }
              i += numSequentialDefaults;
            }
            else
            {
              i += range.TakeWhile(s => s != default(S)).Count();
            }
          }
        }
    
        private S[] CachedData
        {
          get
          {
            if (_cachedData == null)
            {
              // this is necessary so we can instantiate the cache with the correct size.
              var initialData = Load(0, _defaultChunkSize);
    
              _cachedData = new S[_totalRecords.Value];
              AddData(initialData, 0);
            }
    
            return _cachedData;
          }
        }
    
        private static int GetLengthOfSequentialDefaults(IEnumerable<S> range)
        {
          return range.TakeWhile(s => s == default(S)).Count();
        }
      }
    }
