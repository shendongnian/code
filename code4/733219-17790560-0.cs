    var filters = new Dictionary<string, List<string>> { {"Food",  new List<string> { "apple", "tomato", "soup"} },
                                                         {"Drink", new List<string> { "tea"                    }}};
    var table = new System.Data.DataTable();
    table.Columns.Add("Food");table.Columns.Add("Drink");
    table.Rows.Add("apple" , "water");
    table.Rows.Add("tomato", "tea");
    table.Rows.Add("cake"  , "water");
    table.Rows.Add("cake"  , "tea");
    //And: Retrieves only tomato, tea
    var andLinq = table.Rows.Cast<System.Data.DataRow>().Where(row => filters.All(filter => filter.Value.Contains(row[filter.Key])));
    //Or: Retrieves all except cake, water
    var orLinq = table.Rows.Cast<System.Data.DataRow>().Where(row => filters.Any(filter => filter.Value.Contains(row[filter.Key])));
