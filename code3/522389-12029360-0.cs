    var properties = cust.GetType().GetProperties();
    foreach (var prop in properties)
    {
        ListBox1.Items.Add(prop.Name + " = " + prop.GetValue(cust, null));
    }
