    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WhereverYourObjectContextLives;
    /// <summary>
    /// Provides an iterator pattern over a collection such that the results may be processed in parallel.
    /// </summary>
    public abstract class ParallelSkipTakeIterator <T>
    {
        private int currentIndex = 0;
        private int batchSize;
        
        private Expression<Func<T, int>> orderBy;
        private ParallelQuery<T> currentBatch;
        /// <summary>
        /// Build the iterator, specifying an Order By function, and optionally a <code>batchSize</code>.
        /// </summary>
        /// <param name="orderBy">Function which selects the id to sort by</param>
        /// <param name="batchSize">number of rows to return at once - defaults to 1000</param>
        /// <remarks>
        /// <code>batchSize</code> balances overhead with cost of parallelizing and instantiating
        /// new database contexts.  This should be scaled based on observed performance.
        /// </remarks>
        public ParallelSkipTakeIterator(Expression<Func<T, int>> orderBy, int batchSize = 1000)
        {
            this.batchSize = batchSize;
            this.orderBy = orderBy;
        }
        /// <summary>
        /// Accesses the materialized result of the most recent iteration (execution of the query).
        /// </summary>
        public ParallelQuery<T> CurrentBatch
        {
            get
            {
                if (this.currentBatch == null)
                {
                    throw new InvalidOperationException("Must call HasNext at least once before accessing the CurrentBatch.");
                }
                return this.currentBatch;
            }
        }
        /// <summary>
        /// Does the current iterator have another batch of data to process?
        /// </summary>
        /// <returns>true if more data can be accessed via <code>CurrentBatch</code></returns>
        /// <remarks>
        /// Creates a new database context, issues a query, and places a materialized collection in <code>CurrentBatch</code>.
        /// Context is disposed once the query is issued.
        /// Materialized collection is specified by <code>BuildIQueryable</code>.  Use of any associated navigation properties
        /// must be accounted for by using the appropriate <code>.Include</code> operator where the query is
        /// built in <code>BuildIQueryable</code>.
        /// </remarks>
        public bool HasNext()
        {
            using (YourObjectContextHere db = new YourObjectContextHere())
            {
                this.currentBatch = this.BuildIQueryable(db)
                    .OrderBy(this.orderBy)
                    .Skip(this.currentIndex)
                    .Take(this.batchSize)
                    .ToList()
                    .AsParallel();
                this.currentIndex += this.batchSize;
                return currentBatch.Count() > 0;
            }            
        }
        /// <summary>
        /// Given a Database Context, builds a query which can be executed in batches.
        /// </summary>
        /// <param name="db">context on which to build and execute the query</param>
        /// <returns>a query which will be executed and materialized</returns>
        /// <remarks>Context will be disposed as soon a HasNext has been executed.</remarks>
        protected abstract IQueryable<T> BuildIQueryable(YourObjectContextHere db);
    }
