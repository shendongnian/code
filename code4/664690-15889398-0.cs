    public TestConrol()
    {
        InitializeComponent();
        Site = new DummySite(); // note: Site is public, so you can also
                                // write to it from outside the class.
                                // It is also virtual, so you can override
                                // its getter and setter.
    }
