        private UltraGrid rearrangeCol(UltraGrid grid)
        {
            int bandCount = grid.DisplayLayout.Bands.Count;
            int band = 1;
            UltraGridBand b0 = grid.DisplayLayout.Bands[0];
            while (band < bandCount)
            {
                UltraGridBand b = grid.DisplayLayout.Bands[band]
                for (int i = b0.Columns["EndurEndInv"].Index; i < b0.Columns.Count; i++)
                {
                    if(b.Columns.Exists(b0.Columns[i].Key))
                       b.Columns[b0.Columns[i].Key].Header.VisiblePosition = b0.Columns[i].Header.VisiblePosition;
                }
                band++;
            }
            return grid;
        }
