    public partial class GameOverDialog : Window
    {
        delegate void myDelegate();
        public myDelegate RestartChosenEvent;
        public myDelegate ExitChosenEvent;
        
        public GameOverDialog()
        {
            InitializeComponent();
        }
        private void closeAppButton_Click(object sender, RoutedEventArgs e)
        {
            ExitChosenEvent();
            this.Close();
        }
        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            RestartChosenEvent();
            this.Close();
        }
    }
