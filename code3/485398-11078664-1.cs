    foreach (Control cntrl in Panel1.Controls)
    { 
       PropertyInfo prop = cntrl.GetType().GetProperty("Name", BindingFlags.Public |            BindingFlags.Instance);
       if(null != prop && prop.CanWrite)
       {
           prop.SetValue(cntrl, "MyName", null);
       }
    }
