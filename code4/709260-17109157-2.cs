    public class Wall : Element
    {
        public Wall(Walls parent)
        {
            Parent = parent;
        }
    
        public Walls Parent { get; set; }
        public override Elements<Element> ParentRoot
        {
            get
            {
                return new Elements<Element>(Parent);
            }
        }
    }
