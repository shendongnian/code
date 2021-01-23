        public class Master
    {
        [Key()]
        public int MasterId { get; set; }
        public string Name { get; set; }
        public virtual Query2 Query { get; set; }
    }
    public class Query2
    {
        public Query2()
        {
            Columns = new List<Column2>();
        }
        [Key()]
        public int QueryId { get; set; }
        public string Name { get; set; }
        public virtual Master Master { get; set; }
        public virtual ICollection<Column2> Columns { get; set; }
    }
    public class Column2
    {
        [Key()]
        public int ColumnId { get; set; }
        public string Name { get; set; }
        public virtual Query2 Query { get; set; }
        public virtual Query2 ColQuery { get; set; }
    }
