    private static Dictionary<Uri, ResourceDictionary> _uriToResources =
      new Dictionary<Uri, ResourceDictionary>();
    public static ResourceDictionary GetResourceDictionary(Uri uri)
    {
      ResourceDictionary resources;
      if (_uriToResources.TryGetValue(uri, out resources))
      {
        return resources;
      }
      
      try
      {
         resources = (ResourceDictionary)Application.LoadComponent(uri);
      }
      catch
      {
         // could prompt/alert the user here.
         resources = null;
      }
    
      _uriToResources[uri] = resources;
      return resources;
    }
