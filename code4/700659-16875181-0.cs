    class Ancestor
        {
            public interface IAttributes { }
            public IAttributes Attributes;
        }
    
        class Descendant : Ancestor
        {
            public new DescendantAttributes Attributes;  //Shadowing
    
            public Descendant()
            {
                this.Attributes = new DescendantAttributes();
            }
    
            public class DescendantAttributes : IAttributes
            {
                public string Name = "";
            }
        }
