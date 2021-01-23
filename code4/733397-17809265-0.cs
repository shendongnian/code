    [Table(Name="table_type")]
    public class TableType
    {
        [Column(Name="table_type", IsPrimaryKey=true)]
        public int Id { get; set; }
    
        [Column(Name = "value")]
        public String Value { get; set; }
    
        private EntitySet<MainTable> _MainTable = new EntitySet<MainTable>();
        [Association(OtherKey = "TableTypeId", ThisKey = "Id", 
         Storage = "_MainTable")]
        public ICollection<MainTable> MainTable
        {
            get { return _MainTable; }
            set { _MainTable.Assign(value); }
        }
    }
    
    
