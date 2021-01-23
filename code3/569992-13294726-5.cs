    void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //Untested Reflection example. Probably needs some modifying. 
        PropertyInfo prop = typeof(A).GetType()
                  .GetProperty(e.PropertyName, BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo boundProp = typeof(B).GetType()
                  .GetProperty(e.PropertyName, BindingFlags.Public | BindingFlags.Instance);
        boundProp.SetValue (boundItem, prop.GetValue((sender as A),0), null);
    }
