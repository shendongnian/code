    public static void SaveItem(string item1, string item2, int item3, string item4)//TODO rename parameters
    {
        SPListItem newItem = SPContext.Current.Web.Lists["CusomList1"].AddItem();
        //set fields of new item
        newItem.Update();
    }
