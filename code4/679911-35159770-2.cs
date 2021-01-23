    using System;
    using System.Collections.Generic;
    using Z.Expressions.SqlServer.Eval;
    namespace Z.Expressions
    {
        /// <summary>Manager class for eval.</summary>
        public static class EvalManager
        {
            /// <summary>The cache for EvalDelegate.</summary>
            public static readonly SharedCache<string, EvalDelegate> CacheDelegate = new SharedCache<string, EvalDelegate>();
    
            /// <summary>The cache for SQLNETItem.</summary>
            public static readonly SharedCache<string, SQLNETItem> CacheItem = new SharedCache<string, SQLNETItem>();
    		
            /// <summary>The shared lock.</summary>
            public static readonly SharedLock SharedLock;
    
            static EvalManager()
            {
                // ENSURE to create lock first
                SharedLock = new SharedLock();
            }
        }
    }
