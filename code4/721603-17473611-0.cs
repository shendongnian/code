    public class MyComparer : IEqualityComparer<Dictionary<string, object>> {
        public bool Equals(Dictionary<string, object> a, Dictionary<string, object> b) {
            if (a == b) { return true; }
            if (a == null || b == null || a.Count != b.Count) { return false; }
            return !a.Except(b).Any();
        }
    }
    
    IEnumerable<string> columnsToGroupBy = ...
    var rows = tbl.AsEnumerable();
    var grouped = rows.GroupBy(r => columnsToGroupBy.ToDictionary(c => c, c => r[c]), new MyComparer());
    var result = grouped.Select(g => {
        // whatever logic you want with each grouping
        var id = g.Key["id"];
        var sum = g.Sum(r => r.Field<int>("someCol"));
    });
