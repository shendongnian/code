        InitializeComponent();
        AbstractGroup g1 = new Group("Parent 1");
        AbstractGroup s1 = new SubGroup("  Sub 1");
        AbstractGroup s2 = new SubGroup("   Sub 2");
        AbstractGroup g2 = new Group("Parent 2");
        AbstractGroup s3 = new SubGroup("   Sub 1");
        AbstractGroup s4 = new SubGroup("   Sub 2");
        this.DataContext = new List<AbstractGroup>() { g1, s1, s2, g2, s3, s4 };
