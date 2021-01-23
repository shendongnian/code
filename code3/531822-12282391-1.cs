    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace TestApplication
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		private void Window_Loaded(object sender, RoutedEventArgs e)
    		{
    
    		}
    
    		private void Button_Click(object sender, RoutedEventArgs e)
    		{
    			Label l = new Label();
    			l.Background = new LinearGradientBrush(Colors.Black, Colors.Black, 0);
    			l.Foreground = new LinearGradientBrush(Colors.White, Colors.White, 0);
    			canBackArea.Children.Add(l);
    			l.Visibility = System.Windows.Visibility.Visible;
    			l.Content = txtLabelContent.Text;
    			Canvas.SetLeft(l, 20);
    			Canvas.SetTop(l, 20);
    			Canvas.SetZIndex(l, canBackArea.Children.Count);
    		}
    	}
    }
