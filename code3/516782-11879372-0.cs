    public event EventHandler<FooEventArgs> Foo; // produces handler(object sender, FooEventArgs e)
    
    public sealed class FooEventArgs : EventArgs
    {
        public FooEventArgs(int bar)
        {
            this.Bar = bar;
        }
    
        public int Bar { get; private set; }
    }
