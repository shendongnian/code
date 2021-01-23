	using System.Collections.Generic;
	using System.Windows;
	using System.Collections.ObjectModel;
	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			private ViewModel _ViewModel = null;
			public MainWindow()
			{
				InitializeComponent();
				_ViewModel = new ViewModel();
				this.DataContext = _ViewModel;
			}
			private void Button_Click(object sender, RoutedEventArgs e)
			{
				// Moves the first column to the last
				var temp = _ViewModel.OrderedColumns[0];
				_ViewModel.OrderedColumns.Remove(temp);
				_ViewModel.OrderedColumns.Add(temp);
				
			}
		}
		public class ViewModel
		{
			private ObservableCollection<ColumnDescriptor> _OrderedColumns;
			public ObservableCollection<ColumnDescriptor> OrderedColumns
			{
				get { return _OrderedColumns; }
				set { _OrderedColumns = value; }
			}
			private List<Customer> _MyList;
			public List<Customer> MyList
			{
				get { return _MyList; }
				set { _MyList = value; }
			}
			
			public ViewModel()
			{
				OrderedColumns = new ObservableCollection<ColumnDescriptor>();
				OrderedColumns.Add(new ColumnDescriptor() { HeaderText = "Column1", DisplayMember = "Column1" });
				OrderedColumns.Add(new ColumnDescriptor() { HeaderText = "Column2", DisplayMember = "Column2" });
				OrderedColumns.Add(new ColumnDescriptor() { HeaderText = "Column3", DisplayMember = "Column3" });
				OrderedColumns.Add(new ColumnDescriptor() { HeaderText = "Column4", DisplayMember = "Column4" });
				MyList = new List<Customer>();
				
				MyList.Add(new Customer() { Column1 = "Data_Col1", Column2 = "Data_Col2", Column3 = "Data_Col3", Column4 = "Data_Col4" });
				MyList.Add(new Customer() { Column1 = "2Data_Col1", Column2 = "2Data_Col2", Column3 = "2Data_Col3", Column4 = "2Data_Col4" });
			}
		}
		public class ColumnDescriptor
		{
			public string HeaderText { get; set; }
			public string DisplayMember { get; set; }
		}
		public class Customer
		{
			public string Column1 { get; set; }
			public string Column2 { get; set; }
			public string Column3 { get; set; }
			public string Column4 { get; set; }
		}
	}
