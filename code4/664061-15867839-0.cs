    const int neededLines = 5;
    var lines = new List<String>();
    foreach (var s in File.ReadLines("c:\\myfile.txt")) {
        lines.Add(s);
        if (lines.Count > neededLines) {
            lines.RemoveAt(0);
        }
    }
