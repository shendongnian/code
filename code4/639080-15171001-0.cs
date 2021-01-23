        var lines = File.ReadAllLines(@"C:\test.txt");
        for (int i = 0; i < lines.Length; i++) {
            var line = lines[i];
            if (line == "james") {
                lines[i] = "bond";
                lines[i + 1] = "bond@gmail.com";
            }
        }
        File.WriteAllLines(@"C:\test2.txt", lines);
