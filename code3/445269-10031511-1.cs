        /// <summary>
        /// ReOrders a list of partitons placing those with the smallest groups last
        ///   NOTE: this routine assumes that each partitoning lists the smallest 
        ///   integers *first*.
        /// </summary>
        public static IList<List<int>> ReOrderPartitions(IList<List<int>> source)
        {
            // the count is used in several places
            long totalCount= source.Count;
            long k = 0;     // counter to keep the keys unique
            SortedList<long, List<int>> srt = new SortedList<long, List<int>>(source.Count);
            foreach (List<int> prt in source)
            {
                srt.Add(-(prt[0] * totalCount) + k, prt);
                k++;
            }
            return srt.Values;
        }
