    class Ancestor
        {
            public interface IAttributes { }
            public IAttributes Attributes;
        }
    
        class Descendant : Ancestor
        {
            public new DescendantAttributes Attributes;  //Shadowing using new modifier
    
            public Descendant()
            {
                this.Attributes = new DescendantAttributes();
            }
    
            public class DescendantAttributes : IAttributes
            {
                public string Name = "";
            }
        }
