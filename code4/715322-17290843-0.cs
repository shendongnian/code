    private string GetValue(string ControlID)
    {
         string[] keys = Request.Form.AllKeys;
         string value = string.Empty;
         foreach (string key in keys)
         {
             if (key.IndexOf(ControlID) >= 0)
             {
                 value = Request.Form[key].ToString();
                 break;
             }
         }
         return value;
    }
