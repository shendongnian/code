    using (StreamWriter sw = new StreamWriter("out.xml")) {
        foreach (string filename in files) {
            sw.Write(String.Format(@"<inputfile name=""{0}"">", filename));
            using (StreamReader sr = new StreamReader(filename)) {
                // using CopyStream from http://bit.ly/RiovFX, or by reading line by line
                if (max_performance) {
                    CopyStream(sr, sw); 
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
