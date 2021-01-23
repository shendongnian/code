        public static List<T> GetTopN<T>(IQueryable<T> inData, int n)
        {
            List<T> outData = new List<T>(n);
            lock (inData)
            {
                int i = 0;
                foreach (T t in inData)
                {
                    if (i >= n)
                    {
                        return outData;
                    }
                    i++;
                    outData.Add(t);
                }
            }
            return outData;
        }
