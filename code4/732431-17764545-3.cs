    public partial class EntitiesView : UserControl
    {
    
        public EntitiesView()
        {
            InitializeComponent();
            this.DataContext = new TestViewModel();
        }
    }
