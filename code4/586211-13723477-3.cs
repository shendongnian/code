    public interface IDatHandler
    {
        // Any common interface stuff
    }
    public interface IDatHandler<T> : IDatHandler
        where T : IDatContainer
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
