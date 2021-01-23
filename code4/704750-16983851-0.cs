    var sourceFile = txtProcessingFile.Text;
    string[] contents = System.IO.File.ReadAllLines(sourceFile);
    DataTable dt = new DataTable("NewDataTable");
    dt.Columns.Add("CardNo");
    dt.Columns.Add("SNo");
    dt.Columns.Add("Account1");
    dt.Columns.Add("Account2");
    dt.Columns.Add("Account3");
    dt.Columns.Add("Account4");
    dt.Columns.Add("CustomerName");
    dt.Columns.Add("Expiry");
    dt.Columns.Add("Status");
    for (int row = 2; row < contents.Length; row++)
    {
        var newRow = dt.NewRow();
        var regEx = new Regex(@"([\w]*)");
        var matches = regEx.Matches(contents[row].ToString())
            .Cast<Match>()
            .Where(m => !String.IsNullOrEmpty(m.Value))
            .ToList();
        var numbers = matches.Where(m => Regex.IsMatch(m.Value, @"^\d+$")).ToList();
        var names = matches.Where(m => !Regex.IsMatch(m.Value, @"^\d+$")).ToList();
        for (int i = 0; i < numbers.Count() - 1; i++)
        {
            newRow[i] = numbers.Skip(i).First();
        }
        newRow[newRow.ItemArray.Length - 2] = numbers.Last();
        newRow[newRow.ItemArray.Length - 1] = names.Last();
        newRow[newRow.ItemArray.Length - 3] = names.Take(names.Count() - 1).Aggregate<Match, string>("", (a, b) => a += " " + b.Value);
        dt.Rows.Add(newRow);
    }
