    public static EnumDataItemList GetList(Type t)
    {
            EnumDataItemList items = new EnumDataItemList();
        	foreach (int e in Enum.GetValues(t))
            {
               EnumDataItem item = new EnumDataItem();
               item.Text = Enum.GetName(t, e);
               item.Value = e;
            }
          //Rest of code goes here
    }
