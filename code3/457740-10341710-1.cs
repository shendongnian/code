    private PropertyInfo GetPropertyByName(string propName)
    {
      return this.GetType().GetProperty(propName);
    }
    private void GetPath(string PropertyName) {
        //show a dialog, get the path they select
        string newPath = GetPathFromDialog();
        //what should this look like? Is this possible?
        var mProp = GetPropertyByName(PropertyName);
        mPropp.SetValue(this, newPath, null);
    }
