    public void updateCabbageLeaves(Cabbage myCabbage)
        {
            this.CabbageLeaves = myCabbage.Leaves;
        }
    
     public MainWindow()
        {
            InitializeComponent();
    
            ModelView myModelView = new ModelView();
            Cabbage myCabbage = new Cabbage();
            myCabbage.Leaves = 99;
            myModelView.updateCabbageLeaves(myCabbage);
        }
