    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static object testmethod(string serial)
    {
        ItemList itemlist = new ItemList();
        itemlist.Item = "Testing";
        return itemList;
    }
