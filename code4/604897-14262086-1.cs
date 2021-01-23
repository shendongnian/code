    void store_getProducts(object sender, SvcRefstore.getProductsAllCompletedEventArgs e)
    {
        XDocument xReturn = XDocument.Parse(e.Result); // Change is here
         IEnumerable<Products> myQuote = from item in xReturn.Descendants("Products")
                                         select new Products
                                         {
                                             Name = Convert.ToString(item.Element("Name").Value),
                                             unitPrice = Convert.ToString(item.Element("unitPrice").Value),
                                         };
         Products thisQuote = myQuote.ElementAt(0);
         textBlock1.Text = thisQuote.Name.ToString();
    }
