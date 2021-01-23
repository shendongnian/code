    char[] COL_DELIMITER = new[] { '\t' };
    string[] lines = File.ReadAllLines(strPath + strFileName);
    // read the field names from the first line
    var fields = lines[0].Split(COL_DELIMITER, StringSplitOptions.RemoveEmptyEntries).ToList();
    // get a 2-D array of the columns (excluding the header row)
    string[][] columnsArray = lines.Skip(1).Select(l => l.Split(COL_DELIMITER)).ToArray();
    // dictionary of columns with max length
    var max = new Dictionary<string, int>(); 
    // for each field, select all columns, and take the max string length
    foreach (var field in fields)
    {
        max.Add(field, columnsArray.Select(row => row[fields.IndexOf(field)]).Max(col => col.Trim().Length));
    }
    // output per requirment
    Console.WriteLine(string.Join(Environment.NewLine,
            max.Keys.Select(field => field + " " + max[field])
        ));
