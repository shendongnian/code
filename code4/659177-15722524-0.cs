    using(var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("myProg.m‌​yText.txt"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            // Do some stuff here with your textfile
        }
    }
