        private Dictionary<string, int[]> listViewHeaderWidths = new Dictionary<string, int[]>();    
        private void ResizeListViewColumns(ListView lv)
        {
            int[] headerWidths = listViewHeaderWidths[lv.Name];
            lv.BeginUpdate();
            if (headerWidths == null)
            {
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                headerWidths = new int[lv.Columns.Count];
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    headerWidths[i] = lv.Columns[i].Width;
                }
                listViewHeaderWidths.Add(lv.Name, headerWidths);
            }
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for(int j = 0; j < lv.Columns.Count; j++)
            {
                lv.Columns[j].Width = Math.Max(lv.Columns[j].Width, headerWidths[j]);
            }
            lv.EndUpdate();
        }
