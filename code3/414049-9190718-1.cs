        public long GetHistogramMaximum(long[] histogram)
        {
            long result = 0;
            for (int i = 0; i < histogram.Length; i++)
            {
                if (histogram[i] > result)
                {
                    MessageBox.Show(string.Format("{0} is greater than {1}", histogram[i], result);
                    result = histogram[i];
                }
            }
            return result;
        }
