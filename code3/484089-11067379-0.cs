        private double[] Filter(float[] buffer, SignalFilter filter, int count, int index)
        {
            double[] y = new double[count];
            for (int n = 0; n < count; n++)
            {
                for (int k = 0; k < filter.B.Count; k++)
                {
                    if (n - k >= 0)
                    {
                        y[n] = y[n] + filter.B[k] * buffer[n - k];
                    }
                    else if (_cache.GetRawCache ().Count > 0)
                    {
                        double cached =  _cache.GetRawCache ()[_cache.GetRawCache().Count + (n - k)];
                        y[n] = y[n] + filter.B[k] * cached;
                    }
                }
                for (int k = 1; k < filter.A.Count; k++)
                {
                    if (n - k >= 0)
                    {
                        y[n] = y[n] - filter.A[k] * y[n - k];
                    }
                    else if (_cache.GetCache(index).Count > 0)
                    {
                        double cached =  _cache.GetCache(index)[_cache.GetCache(index).Count + (n - k)];
                        y[n] = y[n] - filter.A[k] * cached;
                    }
                }
            }
            return y;
        }
