    public interface IOwlRelation
    {
        OwlClass Parent { get; }
        OwlClass Child { get; }
    }
    
    public class OwlRelation : IOwlRelation
    {
        public OwlClass Parent { get; private set; }
        public OwlClass Child { get; private set; }
    
        public static IOwlRelation Create(OwlClass parent, OwlClass child)
        {
            return new OwlRelation
            {
                Parent = parent,
                Child = child
            };
        }
    }
