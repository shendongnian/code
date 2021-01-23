    using (StreamWriter sw = new StreamWriter("out.xml")) {
        foreach (string filename in files) {
            sw.Write(String.Format(@"<inputfile name=""{0}"">", filename));
            using (StreamReader sr = new StreamReader(filename)) {
                // Using .NET 4's CopyTo(); alternatively try http://bit.ly/RiovFX
                if (max_performance) {
                    sr.CopyTo(sw);
                } else {
                    string line = sr.ReadLine();
                    // parse the line and make any modifications you want
                    sw.Write(line);
                    sw.Write("\n");
                }
            }
            sw.Write("</inputfile>");
        }
    }
