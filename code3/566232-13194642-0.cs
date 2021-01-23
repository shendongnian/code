    public class Foo:IFoo
    {
        public ICollection<IBar> Bars { get; set; }
    }
    Bar bar1 = new Bar();
    Bar bar2 = new Bar();
    Bar[] MyBars = { bar1, bar2 };
    Foo MyFoo = new Foo();
    MyFoo.Bars = MyBars;
