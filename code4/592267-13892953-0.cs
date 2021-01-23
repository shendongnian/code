    protected MascoteAquariumEF model;
    public YourForm()
    {
        InitializeComponent();
    
        if (DesignMode)
            return; // you don't need to create context
    
        model = new MascoteAquariumEF("MascoteAquariumEF");
    }
