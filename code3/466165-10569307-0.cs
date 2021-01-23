    protected class Differences : Dictionary<object, RowDifferences>
    {
    }
    protected class RowDifferences : Dictionary<string, Tuple<object, object>>
    {
    }
    protected Differences GetDifferences(DataTable table1,
                                         DataTable table2,
                                         out IEnumerable<object> onlyIn1,
                                         out IEnumerable<object> onlyIn2)
    {
        var arr1 = new DataRow[table1.Rows.Count];
        var arr2 = new DataRow[table2.Rows.Count];
        table1.Rows.CopyTo(arr1, 0);
        table2.Rows.CopyTo(arr2, 0);
        onlyIn1 = arr1.Where(x1 => arr2.All(x2 => x1[0] != x2[0])).Select(dr => dr[0]);
        onlyIn2 = arr2.Where(x1 => arr1.All(x2 => x1[0] != x2[0])).Select(dr => dr[0]);
        var differences = new Differences();
        foreach (var x1 in arr1)
        {
            foreach (var x2 in arr2)
            {
                if (x1[0] == x2[0])
                {
                    var rowDifferences = new RowDifferences();
                    for (var i = 1; i < x1.ItemArray.Length; i++)
                    {
                        if (x1.ItemArray[i] != x2.ItemArray[i])
                        {
                            rowDifferences.Add(table1.Columns[i].ColumnName,
                                               new Tuple<object, object>(x1.ItemArray[i], x2.ItemArray[i]));
                        }
                    }
                    differences.Add(x1[0], rowDifferences);
                }
            }
        }
        return differences;
    }
    protected void GenerateTables(out DataTable table1, out DataTable table2)
    {
        table1 = new DataTable();
        table2 = new DataTable();
        table1.Columns.Add("Name");
        table1.Columns.Add("Balance");
        table1.Columns.Add("Description");
        table2.Columns.Add("Name");
        table2.Columns.Add("Balance");
        table2.Columns.Add("Description");
        table1.Rows.Add("Smith", 1200, "Smith owes 600");
        table1.Rows.Add("Jordan", 4000, "Hi Jordan");
        table1.Rows.Add("Brooks", 5000, "I like my cat");
        table1.Rows.Add("Navaro", 6000, "description here");
        table1.Rows.Add("Gates", 9010, "omg");
        table2.Rows.Add("Smith", 1600, "Smith owes 600");
        table2.Rows.Add("Jordan", 4200, "I'M JORDAN");
        table2.Rows.Add("Clay", 9000, "Test description");
        table2.Rows.Add("Brooks", 5000, "I like my cat");
    }
