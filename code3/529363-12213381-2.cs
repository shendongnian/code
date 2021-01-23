    class Foo : List<Bar>
    {
        public Foo()
        {
           this.Add(new Bar());
           this.Add(new Bar());
           this.Add(new Bar());
        }
        public void UpdateBars(bool value)
        {
            foreach (var bar in this)
            {
                bar.MyProp = value;
            }
        }
    }
