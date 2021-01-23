    // Load
    var theStrings = new ArrayList();
    var path = GetSavePath();
    if (File.Exists(path)) {
      theStrings.AddRange(File.ReadLines(path);
    }
    // Save:
    File.WriteAllLines(GetSavePath(), theStrings.ToArray());
