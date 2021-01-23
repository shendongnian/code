    public void AddProduct(string productName, decimal latestProductValue, int quantity)
    {
        Form1 newform = new Form1();
        string itemFormatString = "{0,-50}{1,0}{2,50}";
        newform.listBox1.Items.Add(string.Format(itemFormatString, productName, Convert.ToString(quantity), Convert.ToString(latestProductValue)));
    }
