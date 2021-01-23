                 foreach (DataGridViewRow r in DataGridObject.Rows)
        {
            MyDataSource.ForEach( 
                delegate( Product p)
                {
                    if (!string.isNullorWhiteSpace(Convert.ToString(r.Cells["Product"].Value)) && Convert.ToString(r.Cells["Product"].Value).Equals(p.Title,StringComparison.OrdinalIgnoreCase))
                    {
                        tally += p.Price;
                    }
                }
            );
        }
