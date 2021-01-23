    List<string> lines = new List<string>();
    using (StreamReader sr = new StreamReader(filename)) {
        int i=0;
        while (!sr.EndOfStream) {
            string line = sr.ReadLine();
            if (i%2 == 0) lines.Add(line);
        }
    }
