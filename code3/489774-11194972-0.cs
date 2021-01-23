    var qFile = new List<string>();
    public string GetQ()
    {
        string pathFile = "Q.txt";
        Uri uri = new Uri(pathFile, UriKind.Relative); 
        StreamResourceInfo sri = Application.GetResourceStream(uri);
        using (StreamReader sr = new StreamReader(sri.Stream))
        {
            string line = "";
            while ((line != null)
            {
                line = sr.ReadLine());
                if (line != null)
                    qFile.Add(line);  // Add to list
        }
    }
