    public partial class WhackAMole : Window
    {
        public WhackAMole()
        {
            InitializeComponent();
            DataContext = new WhackAMoleViewModel();
        }
    }
