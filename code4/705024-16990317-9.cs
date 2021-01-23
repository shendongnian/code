    using System.Windows;
	using System.Windows.Media;
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
				panel.Children.Add(new MyBox
				{
					Header = "Another box",
					Text = "...",
					BorderBrush = Brushes.Black,
					BorderThickness = new Thickness(1),
					Margin = new Thickness(10)
				});
			}
		}
	}
