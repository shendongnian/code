    public string orderNumber()
    {
       string ord = "ORD" + DateTime.Now.Year + get_next_id();
       ^^^^^^^^^^
       //indicating a local variable, not class level
       return ord;
    }
