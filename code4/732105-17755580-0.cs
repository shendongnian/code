    foreach (string file in Directory.EnumerateFiles("C:\folder"))
    {
       try {
         using (var file = file.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite) {
           Console.WriteLine(file);
         }
       } catch {
         // file is in use
         continue;
       }
    }
