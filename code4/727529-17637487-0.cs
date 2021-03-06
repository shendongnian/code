    // Try to get the old stuff from local storage.
    object oldData = null;
    ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
    bool isFound = settings.Values.TryGetValue("List", out oldData);
    // Save a list to local storage.
    List<string> newData = new List<string>(new string[] { "test", "blah", "blubb" });
    settings.Values["List"] = newData.ToArray();
    // Test whether the saved list contains the expected data.
    Debug.Assert(!isFound || Enumerable.SequenceEqual((string[]) oldData, newData));
