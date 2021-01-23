    private void ConvertToLatLong()
    {
        var lines = from line in System.IO.File.ReadLines(_filename);
                    select line.Split(',').Trim();
        _splitValues = lines.ToList();
    }
