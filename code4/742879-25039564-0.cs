    public void ShowValue(string _Who, bool _Enabled)
    {
    	BrowsableAttribute attribute = (BrowsableAttribute)TypeDescriptor.GetProperties(this.GetType())(_Who).Attributes(typeof(BrowsableAttribute));
    	System.Reflection.FieldInfo fieldToChange = attribute.GetType().GetField("Browsable", Reflection.BindingFlags.NonPublic | Reflection.BindingFlags.Instance | Reflection.BindingFlags.Public | Reflection.BindingFlags.Static | Reflection.BindingFlags.IgnoreCase);
    	fieldToChange.SetValue(attribute, _Enabled);
          //Refresh the Property Grid
    	PG.Refresh();
    }
