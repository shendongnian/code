    public static void CopyGridViewToClipboard(DataGridView gvCopy)
        {
            if (gvCopy == null) return;
            StringBuilder s = new StringBuilder();
            int offset = gvCopy.ColumnHeadersVisible ? 1 : 0;
            int visibleColumnsCount = 0;
            //count visible columns and build mapping between each column and it's display position
            Dictionary<int, int> indexMapping = new Dictionary<int, int>();
            int currIndex = 0;
            int lastFoundMinDisplayIndex = -1;
            for (int j = 0; j < gvCopy.ColumnCount; j++)
            {
                //find min DisplayIndex >= currIndex where column is visible
                int minDisplayIndex = 100000;
                int minDisplayIndexColumn = 100000;
                for (int k = 0; k < gvCopy.ColumnCount; k++)
                {
                    if ((gvCopy.Columns[k].Visible) && (gvCopy.Columns[k].DisplayIndex >= currIndex) && (gvCopy.Columns[k].DisplayIndex > lastFoundMinDisplayIndex))
                    {
                        if (gvCopy.Columns[k].DisplayIndex < minDisplayIndex)
                        {
                            minDisplayIndex = gvCopy.Columns[k].DisplayIndex;
                            minDisplayIndexColumn = k;
                        }
                    }
                }
                if (minDisplayIndex == 100000) break;
                indexMapping.Add(minDisplayIndexColumn, currIndex);
                lastFoundMinDisplayIndex = minDisplayIndex;
                currIndex++;
            }
            visibleColumnsCount = currIndex;
            //put data in temp array -- required to position columns in display order
            string[,] data = new string[gvCopy.RowCount + offset, visibleColumnsCount];
            if (gvCopy.ColumnHeadersVisible)
            {
                for (int j = 0; j < gvCopy.ColumnCount; j++)
                {
                    if (gvCopy.Columns[j].Visible)
                    {
                        data[0, indexMapping[j]] = gvCopy.Columns[j].HeaderText;
                    }
                }
            }
            for (int i = 0; i < gvCopy.RowCount; i++)
            {
                for (int j = 0; j < gvCopy.ColumnCount; j++)
                {
                    if (gvCopy.Columns[j].Visible)
                    {
                        data[i + offset, indexMapping[j]] = gvCopy[j, i].FormattedValue.ToString();
                    }
                }
            }
            //copy data
            for (int i = 0; i < gvCopy.RowCount + offset; i++)
            {
                for (int j = 0; j < visibleColumnsCount; j++)
                {
                    s.Append(data[i, j]);
                    s.Append("\t");
                }
                s.Append("\r\n");
            }
            Clipboard.SetDataObject(s.ToString());
        }
