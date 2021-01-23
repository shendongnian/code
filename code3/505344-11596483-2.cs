    private Stream GetEmbeddedResourceStream(string resourceName)
    {
        Assembly assy = Assembly.GetExecutingAssembly();
        string[] res = assy.GetManifestResourceNames();
        for (int i = 0; i < res.Length; i++)
        {
            if (res[i].ToLower().IndexOf(resourceName.ToLower()) != -1)
            {
                return assy.GetManifestResourceStream(res[i]);
            }
        }
        return Stream.Null;
    }
