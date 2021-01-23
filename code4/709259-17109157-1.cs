    public abstract class Element
    {
        public abstract Elements<Element> ParentRoot { get; }
    }
    public class Elements<T> : List<T> where T : Element
    {
        public Elements<T>() : base()
        {
        }
        public Elements<T>(ICollection<T> collection) : base(collection)
        {
        }
    }
