    public class Person : IPerson 
    {
        public virtual Parent Parent { get; set; }
        IParent IPerson.Parent
        {
           get { return this.Parent; }
           set
           {
              if (!(value is Parent)) throw new ArgumentException();
              this.Parent = (Parent)value;
           }
        }
    }
