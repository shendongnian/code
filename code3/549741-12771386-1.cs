    foreach(string s in args) {
        using( Streamreader sr = new Streamreader(s) ) {
            String line = sr.ReadToEnd();
            Console.WriteLine(line);
        }
    }
