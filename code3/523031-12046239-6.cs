    public class House : Visitable<House>
    {
        public Color Color { get; set; }
    }
    public class Houses : VisitableList<House> {}
