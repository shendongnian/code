    // Cange this:
    // StreamReader sr = new StreamReader("input.txt");
    // String line = sr.ReadLine();
    string line;
    using (StreamReader sr = new StreamReader("input.txt"))
    {
        line = sr.ReadToEnd();
    }
