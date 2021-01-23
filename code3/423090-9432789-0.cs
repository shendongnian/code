    int i = 0;
    ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
    foreach (DictionaryEntry entry in resourceSet)
    {
        object resource = entry.Value;
        if (resource.GetType() == typeof(System.Drawing.Bitmap) || resource.GetType() == typeof(System.Drawing.Icon))
            i++;
    }
    MessageBox.Show(i.ToString());
