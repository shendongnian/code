    public int subPrice()
            {
                if (listBox1.SelectedItems.Count > 0)
                {
                    string SearchString = listBox1.SelectedItem.ToString().Trim();
                    DataSet ds = searchforPrice(SearchString);
    
                    if (ds.Tables["Product"].Rows.Count > 0)
                    {
                        bool success = int.TryParse(maskedTextBox10.Text, out sum);
                        int price = Convert.ToInt32(ds.Tables["Product"].Rows[0]["Price"]);
                        return sum - price;
                    }                
                }
            }
