    public class Parent 
    {
        public virtual string Name 
        { 
            get { return this.name; }
            set { this.name = value != null ? value.trim() : null; }
        }
    }
