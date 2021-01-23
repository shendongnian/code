    interface IHaveSomeInts
    {
        ICollection<int> SomeInts { get; set; }
    }
    class TheClass : IHaveSomeInts
    {
        public List<T> SomeInts { get; set; }
        ICollection<T> IHaveSomeInts.SomeInts
        {
            get { return SomeInts; }
            set { SomeInts = new List<T>(value); }
        }
    }
