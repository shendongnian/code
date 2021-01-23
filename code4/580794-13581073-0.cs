       <Window x:Class="WpfApplication6.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                Title="MainWindow" Height="350" Width="350" Name="UI">
            <Grid Name="Test">
                <UniformGrid Name="UniGrid" />
            </Grid>
        </Window>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
    
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AddRows(new Size(10, 10));
        }
    
        private void AddRows(Size recSize)
        {
            UniGrid.Columns = (int)(UniGrid.ActualWidth / recSize.Width);
            UniGrid.Rows = (int)(UniGrid.ActualHeight / recSize.Height);
            for (int i = 0; i < UniGrid.Columns * UniGrid.Rows; i++)
            {
                UniGrid.Children.Add(new Rectangle { Fill = new SolidColorBrush(Colors.Yellow), Margin = new Thickness(1) });
            }
        }
    }
