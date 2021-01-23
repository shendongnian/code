     ListBox list = new ListBox();
    [WebMethod]
    public static DataSet GetCustomers(string prefixText)
    {
       list .Items.Add(New ListItem(prefixText, 0));
    }
