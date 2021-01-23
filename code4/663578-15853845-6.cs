      int colcount = gw.Columns.Count - 1;
                            //Convert ltr to rtl
                            foreach (DataGridViewColumn GridCol in gw.Columns)
                            {
                                _GridCol[colcount--] = GridCol;
                            }
