    protected void Page_Load(object sender, EventArgs e) 
    {
        Page.Master.MyPropertyChanged += new EventHandler(MasterPropertyChanged);
    }
    protected void MasterPropertyChanged(object sender, EventArgs e) 
        //Rememeber you need the VirtualType in order for this event to be recognized
        SomeLocalValue = Page.Master.MyProperty;
    }
