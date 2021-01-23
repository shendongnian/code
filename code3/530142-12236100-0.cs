    public int ItemCount{ get;set; }
    public string CountText
    {
       get{ return labelId.Text; }
       set{ labelId.Text = "Item in shopcart: "+ ItemCount; }
    }
