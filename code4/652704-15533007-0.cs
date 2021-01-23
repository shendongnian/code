    using System.IO;
    using System.Linq;
    ...
    File.WriteAllLines("output.txt",
                       File.ReadLines("input.txt")
                           .Where(line => !line.Contains("*")));
