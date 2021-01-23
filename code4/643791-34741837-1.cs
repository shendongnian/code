    [WebMethod]       
     public static string SaveClient(object items)       {
        List<object> lstItems = new     JavaScriptSerializer().ConvertToType<List<object>>(items);
      Dictionary<string, object> dic = (Dictionary<string, object>)lstItems[0];
        }
