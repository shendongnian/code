    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    List<string> lines = new List<string>(File.ReadAllLines("file"));
    int lineIndex = lines.FindIndex(line => line.StartsWith("ID2   :"));
    if (lineIndex != -1)
    {
        lines[lineIndex] = "ID2   :NewValue2";
        File.WriteAllLines("file", lines);
    }
