    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    
    namespace ConsoleApplication26
    {
        class FilteredObservableCollection<T> : INotifyCollectionChanged, IEnumerable<T>
        {
            List<T> _FilteredCached;
            ObservableCollection<T> Source;
            Func<T,bool> Filter;
    
            public FilteredObservableCollection(ObservableCollection<T> source, Func<T,bool> filter)
            {
                Source = source;
                Filter = filter;
                source.CollectionChanged += source_CollectionChanged;
            }
    
            void source_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    var addedMatching = e.NewItems.Cast<T>().Where(Filter).ToList();
                    _FilteredCached.AddRange(addedMatching);
                    if (addedMatching.Count > 0)
                    {
                        CollectionChanged(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, addedMatching));
                    }
                }
                else // make life easy and refresh fully
                {
                    _FilteredCached = null;
                    CollectionChanged(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                if (_FilteredCached == null)
                {
                    _FilteredCached = Source.Where(Filter).ToList(); // make it easy to get right. If someone would call e.g. First() only 
                    // we would end up with an incomplete filtered collection.
                }
    
                foreach (var filtered in _FilteredCached)
                {
                    yield return filtered;
                }
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            public event NotifyCollectionChangedEventHandler CollectionChanged = (o,e) => { };
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                ObservableCollection<int> data = new ObservableCollection<int>(new int[] { 1, 2, 3, 4, 1 });
                var filteredObservable = new FilteredObservableCollection<int>(data, x => x > 2);
                Print(filteredObservable); // show that filter works
                data.Add(1);
                Print(filteredObservable); // no change
                data.Add(10);
                Print(filteredObservable); // change
                data.Clear();
                Print(filteredObservable); // collection is empy
                data.Add(5);
                Print(filteredObservable); // add item in filter range
                data[0] = 1;
                Print(filteredObservable); // replace it
            }
    
            static void Print<T>(FilteredObservableCollection<T> coll)
            {
                Console.WriteLine("Filtered: {0}", String.Join(",", coll));
            }
        }
    
    }
