        void MaximumWidth(StreamReader reader)
        {
            string[] columns = null;
            int[]   maxWidth = null;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] cols = line.Split('\t');
                if (columns == null)
                {
                    columns = cols;
                    maxWidth = new int[cols.Length];
                }
                else
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        int width = cols[i].Length;
                        if (maxWidth[i] < width)
                        {
                            maxWidth[i] = width;
                        }
                    }
                }
            }
            // ...
        }
