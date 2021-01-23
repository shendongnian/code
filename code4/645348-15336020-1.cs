    SortedList list = ...
    var listEnumerator = ((IEnumerable)list).GetEnumerator();
    Pair<MyType> pair = null
    do
    {
        pair = Pair.Next<MyType>(listEnumerator);
        ...
    }
    while(pair != null)
...
    class Pair<T>
    {
        public T First {get; set;}
        public T Second {get; set;}
    
        public static Pair<T> Next<T>(IEnumerator enumerator)
        {
            var first = enumerator.Current;
            if(enumerator.MoveNext())
            {
               return new Pair<T>
                   {
                       First = (T)first,
                       Second = (T)enumerator.Current,
                   }
            }
            return null;
        }
    }
