    private void ConvertToLatLong()
    {
        var lines = from line in System.IO.File.ReadLines("foo")
                    let splitLine = line.Split(',')
                    select splitLine.Select(x => x.Trim()).ToArray();
        _splitValues = lines.ToList();
    }
