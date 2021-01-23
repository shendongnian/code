    public class MyEntity
    {
        public MyEntity() { }
        public MyEntity(string Name, int ID, int? ParentID)
        {
            this.Name = Name;
            this.ID = ID;
            this.ParentID = ParentID;
        }
        public string Name { get; set; }
        public int ID { get; set; }
        public int? ParentID { get; set; }
    }
