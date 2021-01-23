    class MyTuple<T1,T2> {
        MyTuple(){}
    
        public T1 Item1{ get;set; }
        public T1 Item2{ get;set; }
    
        public static implicit operator MyTuple(Tuple<T1,T2> t)
        {
             return new MyTuple{
                          Item1 = t.Item1;
                          Item2 = t.Item2;
                        };
        }
    
        public static implicit operator Tuple<T1,T2>(MyTuple t)
        {
             return Tuple.Create(Item1,Item2);
        }
    }
