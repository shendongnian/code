    public class Tree 
    {
        public virtual Tree Parent { get; set; }
        public virtual ICollection<Tree> Children { get; set; }
        public virtual ICollection<Tree> Ancestors { get; set; }
        public virtual ICollection<Tree> Descendants { get; set; }
    }
