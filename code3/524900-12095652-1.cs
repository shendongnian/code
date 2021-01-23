    MyObject data = new MyObject();
    foreach (var pi in typeof(MyObject).GetProperties().Where(i =>
                                          i.PropertyType.Equals(typeof(string)))
    {
       var control = FindControl("txt" + pi.Name) as ITextControl;
       if (control != null)
           pi.SetValue(data, control.Text, null);
    }
