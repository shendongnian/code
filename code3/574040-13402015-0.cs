    public class MyPair<TItem1, TItem2>
    {
        public MyPair(TItem1 item1, TItem2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        public TItem1 Item1 { get; private set; }
        public TItem2 Item2 { get; private set; }
    }
