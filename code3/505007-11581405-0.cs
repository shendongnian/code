    public class BViewModel
    {
        public virtual long Id { get; set; } 
        public virtual AViewModel ItemA { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Date { get; set; }
    }
    public class AViewModel
    {
        public virtual long Id { get; set; }
        public virtual long Number { get; set; }
    }
