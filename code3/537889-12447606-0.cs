     public bool ShouldDeleteLine(string line)
     {
     }
     string tempFile = Path.GetTempFileName();
     var lines = File.ReadLines("list.txt")
                        .Where(line => !ShouldDeleteLine(line));
     File.WriteAllLines(tempFile, lines);
     File.Delete("list.txt");
     File.Move(tempFile, "list.txt");
