    using System.Windows;
	namespace WpfApplication1
	{
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
			private void Button_Click(object sender, RoutedEventArgs e)
			{
				MessageBox.Show(string.Format("{0}\n{1}\n\n{2}\n{3}", box1.Header, box1.Text, box2.Header, box2.Text));
			}
		}
	}
