    String formData = Console.In.ReadToEnd();
    string boundary = string.Empty;
    string[] cPairs = cType.Split(new string[] { "; " }, StringSplitOptions.None);
    foreach (string pair in cPairs) {
    //finds the 'boundary' text
    if (pair.Contains("boundary"))
        boundary = "--" + pair.Split('=')[1];
    }
    //splits on the 'boundary' to get individual form fields/sections
    string[] sections = rawParams.Split(new string[] { boundary }, StringSplitOptions.RemoveEmptyEntries);
    // parse each section
    foreach (string section in sections) {
    string[] parts = section.Split(new string[] { "; ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    if (parts[1].Equals("name=\"dFile\"")) { // 'dFile' is the form field-name for the datafile
        //below lines get the filename
        Regex regx = new Regex("filename=\"(.+)\"", RegexOptions.IgnoreCase);
        Match fPath = regx.Match(parts[2]);
        FileInfo fi = new FileInfo(fPath.Groups[1].Value);
        regx = new Regex("([-A-Z0-9_ .]+)", RegexOptions.IgnoreCase);
        Match fname = regx.Match(fi.Name);
        FileStream fs = File.Create(fname.Groups[1].Value, SOME_SIZE, FileOptions.None))
        BinaryFormatter formatter = new BinaryFormatter();
        //below lines save the file contents to a text file; starts at index 4 of the 'parts' array
        if (fname.Groups[1].Success) {
            for (int i = 4; i < parts.Length; i++) {
                string s = parts[i];
                formatter.Serialize(fs, Encoding.Unicode.GetBytes(s));
            }
        }
    }
    else {
        // parse other non-file form fields
    }
}
