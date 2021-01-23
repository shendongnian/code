    public class Class1<TKey> 
        where TKey : IStructuralEquatable, IStructuralComparable, IComparable
    { 
        public Class1(TKey key)
        {
            Key = key;
            TupleRank = typeof(TKey).GetGenericArguments().Count();
            TupleSubtypes = typeof(TKey).GetGenericArguments();
            Console.WriteLine("Key type is a Tuple (I think) with {0} elements", TupleRank);
            TupleGetters = 
                Enumerable.Range(1, TupleRank)
                    .Select(i => typeof(TKey).GetProperty(string.Concat("Item",i.ToString())))
                    .Select(pi => pi.GetGetMethod())
                    .Select(getter => Delegate.CreateDelegate(
                                typeof(Func<>).MakeGenericType(getter.ReturnType), 
                                this.Key, 
                                getter))
                    .ToList();
        }
    
        public int TupleRank {get; private set;}
        public IEnumerable<Type> TupleSubtypes {get; private set;}
        public IList<Delegate> TupleGetters {get; private set;}
        public TKey Key {get; private set;}
        
        public object this[int rank]
        {
            get { return TupleGetters[rank].DynamicInvoke(null);}
        }
        public void DoSomethingUseful()
        {
            for(int i=0; i<TupleRank; i++)
            {
                Console.WriteLine("Key value for {0}:{1}", string.Concat("Item", i+1), this[i]);
            }
        }
    }
