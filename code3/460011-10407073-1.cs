    public DataTable cartrow(DataTable _cart,string title,int price,int quantity)
    {
    
        tableRow = _cart.NewRow();
        tableRow["Title"] = title;
        tableRow["Price"] = price;
        tableRow["quantity"] = quantity;
        _cart.Rows.Add(tableRow);
        return _cart;
    
    }
