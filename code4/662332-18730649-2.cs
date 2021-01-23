    /// <summary>
    /// Manages open connections on a per-thread basis
    /// </summary>
    public abstract class SqlCeConnectionPool
    {
        private static Dictionary<int, DBCon> threadConnectionMap = new Dictionary<int, DBCon>();
    
        private static Dictionary<int, Thread> threadMap = new Dictionary<int, Thread>();
    
        /// <summary>
        /// The connection map
        /// </summary>
        public static Dictionary<int, DBCon> ThreadConnectionMap
        {
            get { return SqlCeConnectionPool.threadConnectionMap; }
        }
    
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public static ConnectionString ConnectionString
        {
            get { return global::ConnectionString.Default; }
        }
    
        /// <summary>
        /// Gets a connection for this thread, maintains one open one of each.
        /// </summary>
        /// <remarks>Don't do this with anything but SQL compact edition or you'll run out of connections - compact edition is not
        /// connection pooling friendly and unloads itself too often otherwise so that is why this class exists</remarks> 
        /// <returns>An open connection</returns>
        public static DBCon Connection
        {
            get
            {
                lock (threadConnectionMap)
                {
                    //do some quick maintenance on existing connections (closing those that have no thread)
                    List<int> removeItems = new List<int>();
                    foreach (var kvp in threadConnectionMap)
                    {
                        if (threadMap.ContainsKey(kvp.Key))
                        {
                            if (!threadMap[kvp.Key].IsAlive)
                            {
                                //close the connection
                                if (!kvp.Value.Disposed)
                                    kvp.Value.Dispose();
                                removeItems.Add(kvp.Key);
                            }
                        }
                        else
                        {
                            if (!kvp.Value.Disposed)
                                kvp.Value.Dispose();
                            removeItems.Add(kvp.Key);
                        }
                    }
                    foreach (int i in removeItems)
                    {
                        threadMap.Remove(i);
                        threadConnectionMap.Remove(i);
                    }
    
                    //now issue the appropriate connection for our current thread
                    int threadId = Thread.CurrentThread.ManagedThreadId;
    
                    DBCon connection = null;
                    if (threadConnectionMap.ContainsKey(threadId))
                    {
                        connection = threadConnectionMap[threadId];
                        if (connection.Disposed)
                        {
                            if (threadConnectionMap.ContainsKey(threadId))
                                threadConnectionMap.Remove(threadId);
                            if (threadMap.ContainsKey(threadId))
                                threadMap.Remove(threadId);
                            connection = null;
                        }
                        else if (connection.Connection.State == ConnectionState.Broken)
                        {
                            connection.Dispose();
                            if (threadConnectionMap.ContainsKey(threadId))
                                threadConnectionMap.Remove(threadId);
                            if (threadMap.ContainsKey(threadId))
                                threadMap.Remove(threadId);
                            connection = null;
                        }
                        else if (connection.Connection.State == ConnectionState.Closed)
                        {
                            connection.Dispose();
                            if (threadConnectionMap.ContainsKey(threadId))
                                threadConnectionMap.Remove(threadId);
                            if (threadMap.ContainsKey(threadId))
                                threadMap.Remove(threadId);
                            connection = null;
                        }
    
                    }
                    if (connection == null)
                    {
                        connection = new DBCon(ConnectionString);
                        //connection.Connection.Open();
                        if (threadConnectionMap.ContainsKey(threadId))
                            threadConnectionMap[threadId] = connection;
                        else
                            threadConnectionMap.Add(threadId, connection);
                        if (threadMap.ContainsKey(threadId))
                            threadMap[threadId] = Thread.CurrentThread;
                        else
                            threadMap.Add(threadId, Thread.CurrentThread);
    
                    }
                    return connection;
                }
            }
        }
    }
