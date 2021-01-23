    public OrderHeader() { //Executed First
        _number = "";
        _orderDate = DateTime.Now();
    }
    
    public OrderHeader(string Number)
                : this()
            {
              _number = Number;
            }
    
    public OrderHeader(string Number, DateTime OrderDate, int ItemQty)
                : this(Number)
            {
    
               _orderDate = OrderDate;
               _itemQty = ItemQty;
            }
