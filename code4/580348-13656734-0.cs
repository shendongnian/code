    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    var stream = assembly.GetManifestResourceStream("View.Maps.Breakout_" + _breakoutSelection + ".txt");
    using (var streamReader = new StreamReader(stream))
    {
        int y = 0;
        while (!streamReader.EndOfStream)
        {
            string data = streamReader.ReadLine();
            int x = 0;
            foreach (var mapSquare in data)
            { code here }
        }
    }
