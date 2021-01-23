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
                    string colKey = b0.Columns[i].Key;
                    if(b.Columns.Exists(colKey))
                        b.Columns[colKey].Header.VisiblePosition = 
                                       b0.Columns[colKey].Header.VisiblePosition;
                }
                band++;
            }
            return grid;
        }
