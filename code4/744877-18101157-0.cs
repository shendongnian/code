    var filesToDelete = System.IO.Directory.GetFiles(@"..\DATA\data", "*.pdf");
    filesToDelete = Array.FindAll(filesToDelete, p => p.Contains("TOPRINT"));
            
    Array.ForEach(filesToDelete, System.IO.File.Delete); // or
    // Array.ForEach(filesToDelete, p => System.IO.File.Delete(p));            
    // or, better,  foreach (var file in filesToDelete) { System.IO.File.Delete(file); }
