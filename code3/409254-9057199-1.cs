    public static EnumDataItemList GetList<T>() where T : struct
    {
        EnumDataItemList items = new EnumDataItemList();
    	foreach (int e in Enum.GetValues(typeof(T)))
        {
           EnumDataItem item = new EnumDataItem();
           item.Text = Enum.GetName(typeof(T), e);
           item.Value = e;
        }
      //Rest of code goes here
    }
