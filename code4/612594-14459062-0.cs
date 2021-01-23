    public abstract class A, ICollection
    {
        public abstract int Count { get; }
        //todo realize ICollection
    }
    public class B<T> : A, ICollection 
    {
        protected List<T> BList = new List<T>();
        public override int Count 
        {
            return BList.Count;
        }
        //todo realize ICollection
    }
