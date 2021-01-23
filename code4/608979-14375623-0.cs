    public class JustOneColumn
    {
        public string value { get; set; }
    }
    
    ... qgv.db.QueryAsync<JustOneColumn>("SELECT DISTINCT MyCol FROM ...");
