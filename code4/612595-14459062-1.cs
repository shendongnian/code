    public abstract class A, ICollection
    {
        public abstract int Count { get; }
        //todo realize ICollection
    }
    public class B<T> : A
    {
        protected List<T> OtherObject = new List<T>();
        public override int Count 
        {
            get
            {
                return OtherObject.Count;
            }
        }
        //todo realize ICollection
    }
