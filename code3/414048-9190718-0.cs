        public long GetHistogramMaximum(long[] histogram)
        {
            long result = 0;
            long count = 0;
            for (int i = 0; i < histogram.Length; i++)
            {
                if (histogram[i] > 0)
                {
                    MessageBox.Show(histogram[i].ToString());
                    break;
                }
            }
            return result;
        }
