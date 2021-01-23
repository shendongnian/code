    IEnumerable<string> inserts = // add your insert-strings here;
    string firstInsert = inserts.First();
    int tableIndex = firstInsert.IndexOf("INSERT INTO ") + "INSERT INTO ".Length;
    string table = firstInsert.Substring(
        tableIndex, firstInsert.IndexOf("(", tableIndex) - tableIndex);
    var regex = new System.Text.RegularExpressions.Regex(@"\(([^)]+)\)",System.Text.RegularExpressions.RegexOptions.Compiled);
    string columns = regex.Matches(firstInsert)[0].Value;
    IEnumerable<string> values = inserts.Select(sql => regex.Matches(sql)[1].Value);
    string insertAll = string.Format("INSERT INTO {0}{1} VALUES {2};"
        , table
        , columns
        , string.Join(",", values));
