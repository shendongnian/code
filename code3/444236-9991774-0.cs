    public class Pair<T> : Tuple<T, T>
    {
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
