    public class ExtendedTable
    {
        public int NotTheSameNameID { get; set; }
        public string AnotherTableColumn { get; set; }
        public string Name { get { return MainEntry.Name; } set { MainEntry.Name = value; } }
        // public int MainID { get { return MainEntry.ThePrimaryKeyId; } set { MainEntry.ThePrimaryKeyId = value; } }
        internal MainTable MainEntry { get; set; }
        public ExtendedTable()
        {
            this.MainEntry = new MainTable();
        }
    }
