    public class Pair<T> : Tuple<T, T>
    {
        public Pair<T>(T item1, T item2) : base(item1, item2)
        {           
        }
        public T this[int index]
        {
           get
           {
               if (index == 0)
                   return Item1;
               else if (index == 1)
                   return Item2;
               throw new ArgumentOutOfRangeException("index");
           }
        }
    }
