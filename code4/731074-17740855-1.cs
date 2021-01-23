    public void AddProduct(Form1 form, string productName, decimal latestProductValue, int quantity)
    {
        string itemFormatString = "{0,-50}{1,0}{2,50}";
        form.listBox1.Items.Add(string.Format(itemFormatString, productName, Convert.ToString(quantity), Convert.ToString(latestProductValue)));
    }
