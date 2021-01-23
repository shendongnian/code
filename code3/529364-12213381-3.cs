    class Foo : List<Bar>
    {
        public Foo()
        {
           this.Add(new Bar());
           this.Add(new Bar());
           this.Add(new Bar());
        }
        public bool MyProp
        {
            set
            {
                foreach (var bar in this)
                {
                    bar.MyProp = value;
                }
            }
        }
    }
