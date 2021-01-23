    public int subPrice()
            {
    
                DataSet ds = searchforPrice(((ListBoxItem)listBox1.SelectedValue).Content.ToString());
                int sum;
                bool success = int.TryParse(maskedTextBox10.Text, out sum);
                int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Price"]);
                return sum - price;
    
            }
