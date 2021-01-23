    class Foo
    {
        private readonly IList<Bar> bars = new List<Bar>
            {
                new Bar(),
                new Bar(),
                new Bar()
            }
        public Bar this[int i]
        {
            get
            {
               return this.bars[i];
            }
        }
        public void UpdateBars(bool value)
        {
            foreach (var bar in this.bars)
            {
                bar.MyProp = value;
            }
        }
    }
