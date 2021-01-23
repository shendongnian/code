        public class SharedStringClass
        {
            private static readonly int TRUE = 1;
            private static readonly int FALSE = 0;
    
            private static int allowEntry;
    
            private static AutoResetEvent autoResetEvent;
    
            private IList<string> internalCollection;
    
            public SharedStringClass()
            {
                internalCollection = new List<string>();
                autoResetEvent = new AutoResetEvent(false);
                allowEntry = TRUE;
            }
    
            public void AddString(string strToAdd)
            {
                CheckAllowEntry();
    
                internalCollection.Add(strToAdd);
    
                // set allowEntry to TRUE atomically
                Interlocked.Exchange(ref allowEntry, TRUE);
                autoResetEvent.Set();
            }
    
            public string ToString()
            {
                CheckAllowEntry();
    
                // access the shared resource
                string result = string.Join(",", internalCollection);
    
                // set allowEntry to TRUE atomically
                Interlocked.Exchange(ref allowEntry, TRUE);
                autoResetEvent.Set();
                return result;
            }
    
            private void CheckAllowEntry()
            {
                while (true)
                {
                    // compare allowEntry with TRUE, if it is, set it to FALSE (these are done atomically!!)
                    if (Interlocked.CompareExchange(ref allowEntry, FALSE, TRUE) == FALSE)
                    {
                        autoResetEvent.WaitOne();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
