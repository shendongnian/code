     foreach (DataGridViewRow r in DataGridObject.Rows)
            {
                MyDataSource.ForEach( 
                    delegate( Product p)
                    {
                        if(r.Cells["Product"]!=null)
                         {
                          if(r.Cells["Product"].Value!=null)
                          {
                            if (r.Cells["Product"].Value.ToString() == p.Title)
                            {
                              tally += p.Price;
                            }
                          }
                        }
                    }
                );
            }
