    var stateList = new List<String>();
    var countyList = new List<String>();
    var zipCodeList = new List<String>();
    var latitudeList = new List<String>();
    var longitudeList = new List<String>();
    using (var reader = new System.IO.StreamReader(@"C:\Temp\csv.txt"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            var fields = line.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            stateList.Add(fields[0]);
            if (fields.Length > 1)
                countyList.Add(fields[1]);
            if (fields.Length > 2)
                zipCodeList.Add(fields[2]);
            if (fields.Length > 3)
                latitudeList.Add(fields[3]);
            if (fields.Length > 4)
                longitudeList.Add(fields[4]);
        }
    }
