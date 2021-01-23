    var data = System.IO.File.ReadAllLines(@"C:\Temp\Data.csv");
    var result = new List<String>();
    var errors = new List<Tuple<int, String, String>>();
    for (int i = 0; i < data.Length; i++)
    {
        var line = data[i];
        var cols = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (cols[0].ToUpper() == "ERROR")
        {
            var errorInfo = Tuple.Create(i, line, data[i+1]);
            errors.Add(errorInfo);
            i++;
        }
        else {
            result.Add(line);
        }
    }
    foreach(var error in errors)
    {
        result.Add(error.Item2);
        result.Add(error.Item3);
    }
