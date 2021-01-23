    //InfiniteList<T> is a list of itself...
    public class InfiniteList<T> : List<InfiniteList<T>>
    {
        //This is necessary to allow your lists to store values (of type T).
        public T Value { set; get; }
    }
