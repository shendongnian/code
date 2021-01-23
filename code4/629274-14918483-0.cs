    public int addPrice()
    {
        DataSet ds = searchforPrice(comboBox2.Text);
        int sum = Convert.ToInt32(maskedTextBox10.Text);
        int price =  Convert.ToInt32(ds.Tables[0].Rows[0]["Price"]);
        return sum + price;
    }
