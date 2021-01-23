    public static class JavaScript
    {
        public static string Serialize(object o)
        {            
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
