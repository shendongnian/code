	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Input;
	using System.Windows.Controls;
	using System.Collections.ObjectModel;
	namespace WpfApplication1
	{
		public partial class MainWindow : Window
		{
			public class Picture
			{
				public string Name { get; set; }
			}
			public string Text { get; set; }
			public ObservableCollection<string> Pictures1 { get; set; }
			public ObservableCollection<Picture> Pictures2 { get; set; }
			public MainWindow()
			{
				InitializeComponent();
				Pictures1 = new ObservableCollection<string>();
				Pictures2 = new ObservableCollection<Picture>();
				DataContext = this;
			}
			private void Button_Click(object sender, RoutedEventArgs e)
			{
				Pictures1.Add(Text);
				Pictures2.Add(new Picture { Name = Text });
				list1.SelectedItem = Pictures1[0];
				list2.SelectedItem = Pictures2[0];
			}
		}
	}
