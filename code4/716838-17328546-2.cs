    select 'firstValue', 'HITHERE'
    union
    select 'secondValue', 'HOTHERE'
    public class resultsClass
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    var results = DataContext.Database.SqlQuery<resultsClass>(testQuery);
