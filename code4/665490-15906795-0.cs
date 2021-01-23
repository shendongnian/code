    private bool CheckFlagStatus(string directory)
    {
        badFlags = new[] { 1, 5, 6, 42, 61};
        string flagFilePath = Path.Combine(directory, "flags.csv" );
        if (File.Exists(flagFilePath))
        {
            var lines = File.ReadLines(flagFilePath)
                            .Where(line => !string.IsNullOrEmpty(line));
            foreach (var line in lines)
            {
                var splitval = line.Split(',');
                if (splitval.Length == 2)
                {
                    var flagString = splitval.Last();
                    int flag;
                    if (int.TryParse(flagString, out flag))
                    {
                        if (badFlags.Contains(flag)) return false;
                    }
                }
            }    
        }
        return true;
    }
