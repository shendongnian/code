    Type myType = this.GetType();
    IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
    foreach (PropertyInfo prop in props)
    {
        if (prop.PropertyType.IsSubclassOf(typeof(DelegateCommandBase)))
        {
            var cmd = (DelegateCommandBase)prop.GetValue(this, null);
            cmd.RaiseCanExecuteChanged();
        }
    }
