     public class FrequencyOfMatchedHash : Dictionary<int,int>
    { 
        public void AddRecordHash(int hashCode)
        {
            if (this.ContainsKey(hashCode))
            {
                this[hashCode]++;
            }
            else
            {
                this.Add(hashCode, 1);
            }
        }
        public void DecrementRecordHash(int hashCode)
        {
            if (this.ContainsKey(hashCode))
            {
                var val = this[hashCode];
                if (val <= 1)
                {
                    this.Remove(hashCode);
                }
            } 
        }
        public override string ToString()
        {
            return this.Count + " records";
        }
    }
    public class HashDuplicateTracker : Dictionary<int, int >
    {
        internal void AddRecord(int recordHash)
        {
            if (this.ContainsKey(recordHash))
            {
                this[recordHash]++;
            }
            else
            {
                this.Add(recordHash, 1);
            }
        }
    }
    
    public class HashesByDate : SortedDictionary<DateTime, FrequencyOfMatchedHash>
    {
        internal void AddRecord(DateTime dt, int recordHash)
        {
            if (this.ContainsKey(dt))
            {
                this[dt].AddRecordHash(recordHash);
            }
            else
            {
                var tmp = new FrequencyOfMatchedHash();
                tmp.AddRecordHash(recordHash);
                var tmp2 = new FrequencyOfMatchedHash();
                tmp2.AddRecordHash(recordHash);
                this.Add(dt, tmp);
            }
        }
    }
    public class DuplicateTracker
    {
        HashDuplicateTracker hashDuplicateTracker = new HashDuplicateTracker();
        // track all the hashes by date
        HashesByDate hashesByDate = new HashesByDate();
        private TimeSpan maxRange;
        private int average;
        public DuplicateTracker(TimeSpan range)
        {
            this.maxRange = range;
        }
        public void AddRecordHash(DateTime dt, int recordHash)
        {
            if (hashesByDate.Count == 0)
            {
                hashDuplicateTracker.AddRecord(recordHash);
                hashesByDate.AddRecord(dt, recordHash);
               
                return;
            }
            else
            {
                // Cleanup old data
                DateTime maxDate = hashesByDate.ElementAt(hashesByDate.Count - 1).Key;
                DateTime oldestPermittedEntry = maxDate - maxRange;
                if (dt >= oldestPermittedEntry)
                    try
                    {
                        hashDuplicateTracker.AddRecord(recordHash);
                        hashesByDate.AddRecord(dt, recordHash);
                        
                        CheckDataFreshness(oldestPermittedEntry);
                    }
                    catch (ArgumentException e)
                    {
                        // An entry with the same key already exists.
                        // Increment count/freshness
                        hashesByDate[dt].AddRecordHash(recordHash);
                        hashDuplicateTracker[recordHash]++;
                        CheckDataFreshness(oldestPermittedEntry);
                    }
            }
        }
        /// <summary>
        /// This should be called anytime data is added to the collection
        /// 
        /// If threading issues are addressed, a more optimal solution would be to run this on an independent thread.
        /// </summary>
        /// <param name="oldestEntry"></param>
        private void CheckDataFreshness(DateTime oldestEntry)
        {
            while (hashesByDate.Count > 0)
            {
                DateTime currentDate = hashesByDate.ElementAt(0).Key;
               
                if (currentDate < oldestEntry)
                {
                    var hashesToDecrement = hashesByDate.ElementAt(0).Value;
                    for (int i = 0; i < hashesToDecrement.Count; i++)
                    {
                        int currentHash = hashesToDecrement.ElementAt(0).Key;
                        int currentValue = hashesToDecrement.ElementAt(0).Value;
                        // decrement counter for hash
                        int tmpResult = hashDuplicateTracker[currentHash] - currentValue;
                        if (tmpResult == 0)
                        {
                            // prevent endless memory growth.
                            // For performance this might be deferred 
                            hashDuplicateTracker.Remove(tmpResult);
                        }
                        else
                        {
                            hashDuplicateTracker[currentHash] = tmpResult;
                        }
                        // remove item
                        continue;
                    }
                    hashesByDate.Remove(currentDate);
                }
                else
                    break;
            }
        }
     }
