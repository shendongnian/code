    int i = 0;
    ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
    foreach (DictionaryEntry entry in resourceSet)
    {
        string resourceName = entry.Key; //if you need all this, but who knows.
        object resource = entry.Value;
        if ((resource.GetType() == typeof(System.Drawing.Bitmap) || resource.GetType() == typeof(System.Drawing.Icon)) && 
             resourceName == "someString")
        {
            i++;
        }    
    }
    MessageBox.Show(i.ToString());
