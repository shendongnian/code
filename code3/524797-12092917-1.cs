    class EventMangler {
    
       private static readonly _instance = new SomeHandler ();
    
       // although you don't like static methods  :(
       static EventMangler Instance {
          get { return _instance; }
    
       public void SomeEventHandler (object sender, EventArgs e) {
          // handle event
       }
    }
    // use EventMangler.Instance
    public MyForm () {
       InitializeComponent();
       button1.Click += EventMangler.Instance.SomeEventHandler;
    }
