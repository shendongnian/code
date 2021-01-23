    public class MyEventArgs : EventArgs
    {
        public MyEventArgs()
        {
            Results = new List<int>();
        }
        public string InputString{get;set;}
        public List<int> Results{get;set;}
    }
    public event EventHandler<MyEventArgs> Ev
    public int Do(string l)
    {
        MyEventArgs e = new MyEventArgs();
        e.InputString = l;
        if(Ev != null) Ev(this, e);
        return e.Results.Sum();
    }
