    namespace DrawSomeStuff
    {
    public partial class MainWindow : Window
    {
        Point mousePosition;
        Image chalk;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Get mouse position
            mousePosition = Mouse.GetPosition(this);
            //Set chalk
            chalk = new Image();
            chalk.RenderSize = new Size(5, 5);
            //Set chalk image
            //Move and add chalk
            chalk.TranslatePoint(mousePosition, this);
            this.AddChild(chalk);
        }
    }
    }
