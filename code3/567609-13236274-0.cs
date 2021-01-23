    XDocument xdoc = XDocument.Load("Customers.xml");
            xdoc.Root.Add(new XElement("customer", "Stephano"));
    xdoc.Save();
    PopulateCustomersList(xdoc);
    private void PopulateCustomersList(XDocument xdoc)
         {
             foreach(XElement in element xdoc.Root.Elements("customer"))
             {
                customersList.Items.Add(new ListBoxItem()
                 {
                    Content = (string)element;
                 }
             }
         }
