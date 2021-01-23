    public interface IDatHandler
    {
        // Any common interface implementation
    }
    public interface IDatHandler<T> : IDatHandler
    {
        // Any generics
        List<T> Items;
    }
    public class ADEColorHandler : IDatHandler<ADEColor>
    {
      ....
        public List<ADEColor> Items
        {
            get; set;
        }
    }
