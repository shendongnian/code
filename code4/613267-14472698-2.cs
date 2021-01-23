    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication1
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
    
    		private void textBox1_KeyUp(object sender, KeyEventArgs e)
    		{
    			if (e.Key == Key.Enter)
    			{
    				e.Handled = true;
    				MessageBox.Show("Enter Fired!");
    			}
    		}
    	}
    }
