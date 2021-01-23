    public string Serialize(object o)
    {
        string result = ""; // TODO: user string builder
        Type type = o.GeyType();
        foreach (var pi in type.GetProperties())
        {
            string name = pi.Name;
            string value = pi.GetValue(o, null).ToString();
            object[] attrs = pi.GetCustomAttributes(true);
            foreach (var attr in attrs)
            {
               var vp = attr as FIXValuePairAttribute;
               if (vp != null) name = vp.Name;
            }
            result += name + "=" + value + ";";
        }
        return result;
    }
