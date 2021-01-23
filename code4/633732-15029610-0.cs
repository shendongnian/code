    public class ExtJsGridJsonModel<T>
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }
    
        [DataMember(Name = "rows")]
        public IEnumerable<T> Rows { set; get; }
    
        public ExtJsGridJsonModel(IEnumerable<T> rows, int total)
        {
            this.Rows = rows;
            this.Total = total;
        }
    }
