    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			DataContext = new MyViewModel();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			MyViewModel viewModel = DataContext as MyViewModel;
			viewModel.PropertyChanged += MyPropertyChangedEventHandler;
			viewModel.NotifyPropertyChanged();
		}
		private void MyPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			Console.WriteLine(e.PropertyName);
		}
	}
	public class MyViewModel : INotifyPropertyChanged
	{
		public void NotifyPropertyChanged()
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs("MyTestPropertyName"));
			}
		}
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
