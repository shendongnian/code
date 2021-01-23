    using System.Windows;
	using System.Windows.Media;
	using System.Windows.Input;
	using System.Windows.Controls;
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
				MyBox box = new MyBox
				{
					Header = "Another box",
					Text = "...",
					BorderBrush = Brushes.Black,
					BorderThickness = new Thickness(1),
					Margin = new Thickness(10)
				};
				box.MouseLeftButtonDown += Box_MouseLeftButtonDown;
				box.MouseLeftButtonUp += Box_MouseLeftButtonUp;
				box.MouseMove += Box_MouseMove;
				panel.Children.Add(box);
			}
			private MyBox draggedBox;
			private Point clickPosition;
			private void Box_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
			{
				draggedBox = sender as MyBox;
				clickPosition = e.GetPosition(draggedBox);
				draggedBox.CaptureMouse();
			}
			private void Box_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
			{
				draggedBox.ReleaseMouseCapture();
				draggedBox = null;
			}
			private void Box_MouseMove(object sender, MouseEventArgs e)
			{
				if (draggedBox != null)
				{
					Point currentPosition = e.GetPosition(panel);
					draggedBox.RenderTransform = draggedBox.RenderTransform ?? new TranslateTransform();
					TranslateTransform transform = draggedBox.RenderTransform as TranslateTransform;
					transform.X = currentPosition.X - clickPosition.X - draggedBox.Margin.Left;
					transform.Y = currentPosition.Y - clickPosition.Y - draggedBox.Margin.Right;
				}
			}
		}
	}
