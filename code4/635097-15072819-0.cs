    Type theType = this.GetType();
    FieldInfo[] fi = theType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
    foreach ( FieldInfo f in fi)
    {
        //Do your own object identity check
        //if (f is what im looking for)
        {
            Control c = f.GetValue(this) as Control;
            c.Enabled = bEnabled;
        }
        //Note: both sets of code do the same thing
        //OR you could use pure reflection
        {
            f.GetValue(this).GetType().GetProperty("Enabled").SetValue(f.GetValue(this), bEnabled, null);
        }
    }
