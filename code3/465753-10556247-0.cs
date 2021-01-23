    var set = new Set<string>(listOfDatabases);
    var list = new List<string>();
    foreach (string fullPath in listOfFullPaths) {
      var name = Path.GetFileNameWithoutExtension(fullPath);
      if (set.Contains(name)) {
        list.Add(fullPath);
      }
    }
    listOfFullPaths = list;
