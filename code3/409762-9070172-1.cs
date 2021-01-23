     tb1.ID = "txtDateRow" + x + "Col" + j;
                 tb1.Text = ds.Tables[0].Rows[x]["Date"].ToString();
                 tb2.ID = "txtDetails" + x + "Col" + j;
                 tb2.Text = ds.Tables[0].Rows[x]["AmountSold"].ToString();
                 cell.Controls.Add(tb1);
                 cell.Controls.Add(tb2);
                 table.Rows.Add(row);
