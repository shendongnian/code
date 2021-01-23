     protected void AddTheseItemsToMyShoppingBagButton_Click(object sender, EventArgs e)
     {
            for (int x = 0; x < RapidOrderEntry.Rows.Count; x++)
            {
                for (int y = 0; y < RapidOrderEntry.Rows[x].Cells.Count; y++)
                {
                    TextBox tb = (TextBox)RapidOrderEntry.Rows[x].Cells[y].FindControl(string.Format("QuantityTextBox_{0}_{1}", x, y));
                    int t = Int32.Parse((tb).Text);
                }
            }
     }
