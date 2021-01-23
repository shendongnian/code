    using System.Linq;
    string columnName = "SomeColumnName;"
    string matchPattern = "matchPattern";
    
    // returns rows which contains pattern in specific columns
    var result = tbl.AsEnumerable()
                    .Select(f => f.Field<string>(columnName))
                    .Where(c => c.Contains(matchPattern));
    
    
    // returns true if all rows contains pattern in specific column
    var result = tbl.AsEnumerable()
                    .Select(f => f.Field<string>(columnName))
                    .All(c => c.Contains(matchPattern));
