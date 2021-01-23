    var idToDelete = "1";
    var path = @"C:\Temp\Test.txt";
    var lines = File.ReadAllLines(path);
    using (var writer = new StreamWriter(path, false)) {
        for (var i = 0; i < lines.Length; i++) {
            var line = lines[i];
            //assuming it's a CSV file
            var cols = line.Split(',');
            var id = cols[cols.Length - 1];
            if (id != idToDelete) {
                writer.WriteLine(line);
            }
        }
    }
