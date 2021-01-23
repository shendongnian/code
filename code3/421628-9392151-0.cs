    public string ReturnProperty(object ob, string prop)
    {
        Type type = ob.GetType();
        PropertyInfo pr = type.GetProperty(prop);
        //Here pr is null..Dont know whats wrong
        return pr.GetValue(ob, null).ToString();
    }
    ReturnProperty(new { abc = 10 }, "abc");
