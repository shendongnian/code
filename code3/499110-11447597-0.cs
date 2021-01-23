    public class Root
    {
        public int RootId { get; set; }
        public Table1 Table1 { get; set; }
        private Table2 Table2
        {
            get { return Table1.Table2; }
            set { Table1.Table2 = value; }
        }
    }
