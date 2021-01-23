    public static Dictionary<string, int> GetStrFieldsLen()
    {
        Dictionary<string, int> dicFieldLen = new Dictionary<string, int>();
        var myEntity = new myEntity();
        foreach(var m in myEntity.GetType().GetProperties())
        {
            var typeName = myEntity.GetType().GetProperty(m.Name).PropertyType;
            int iLen = 0;
            if (typeName == typeof(string))
            {
                var tv= (m.CustomAttributes).First().NamedArguments.ToArray()[0].TypedValue.ToString(); // Get DbType member
                 int idxStart = tv.LastIndexOf("(") + 1;
                 if (int.TryParse(tv.Substring(idxStart, tv.LastIndexOf(")") - idxStart), out iLen)==false)
                    iLen= int.MaxValue; // Field length is MAX
                 dicFieldLen.Add(m.Name, iLen);
             }
        }
        return dicFieldLen ;
    }
