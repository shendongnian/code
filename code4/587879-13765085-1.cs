    class DataColComparer:Comparer<DataCol>
    {
        public override int Compare(DataCol x, DataCol y)
        {
           if(ReferenceEquals(x,y))
             return 0;
           if(x==null)
             return -1;
           if(y==null)
             return +1;
           return Comparer<TValue>.Default.Compare(y.Value, x.Value);
        }
    }
