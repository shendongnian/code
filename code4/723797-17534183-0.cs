    public class NamedChild
    {
        public int ChildID {get; set;}
        public string Name {get; set;}
        protected NamedChild() {}
        public NamedChild(UnnamedChild c, string Name)
        {
            this.ChildID = c.ChildID;
            this.Name = Name;
        }
    }
