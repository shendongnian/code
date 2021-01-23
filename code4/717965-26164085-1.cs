    public class Table1
    {
        public Table1()
        {
            Table2s = new List<Table2>();
        }
        public Guid Id { get; set; }
        public IList<Table2> Table2s { get; private set; }
        public override bool Equals(object obj)
        {
            if (obj as Table1 == null) throw new ArgumentException("obj is null or isn't a Table1", "obj");
            return this.Id == ((Table1)obj).Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
	
	public class Table2
    {
        public Table2()
        {
            Table3s = new List<Table3>();
        }
		
        public Guid Id { get; set; }
        public Guid Table1Id
        {
            get
            {
                if (Table1 == null)
                    return default(Guid);
                return Table1.Id;
            }
        }
        public IList<Table3> Table3s { get; private set; }
        public Table1 Table1 { get; set; }
        public override bool Equals(object obj)
        {
            if (obj as Table2 == null) throw new ArgumentException("obj is null or isn't a Table2", "obj");
            return this.Id == ((Table2)obj).Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
	
	public class Table3
    {
        public Table3()
        {
        }
        public Guid Id { get; set; }
        public Guid Table2Id
        {
            get
            {
                if (Table2 == null)
                    return default(Guid);
                return Table2.Id;
            }
        }
        public Table2 Table2 { get; set; }
        public override bool Equals(object obj)
        {
            if (obj as Table3 == null) throw new ArgumentException("obj is null or isn't a Table3", "obj");
            return this.Id == ((Table3)obj).Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
	
