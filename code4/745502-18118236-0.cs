	using GalaSoft.MvvmLight.Command;
	using System;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	namespace WPF2
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
			private void Button_Click(object sender, RoutedEventArgs e)
			{
				txtID.GetBindingExpression(TextBox.TextProperty).UpdateSource();
				txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
				txtPrice.GetBindingExpression(TextBox.TextProperty).UpdateSource();
			}
		}
		public class MainWindowViewModel : INotifyPropertyChanged
		{
			public const string ProductsPropertyName = "Products";
			private ObservableCollection<Product> _products;
			public ObservableCollection<Product> Products
			{
				get
				{
					return _products;
				}
				set
				{
					if (_products == value)
					{
						return;
					}
					_products = value;
					RaisePropertyChanged(ProductsPropertyName);
				}
			}
			private Product _SelectedProduct;
			public Product SelectedProduct
			{
				get { return _SelectedProduct; }
				set
				{
					_SelectedProduct = value;
					RaisePropertyChanged("SelectedProduct");
				}
			}
			private ICommand _UpdateCommand;
			public ICommand UpdateCommand
			{
				get
				{
					if (_UpdateCommand == null)
					{
						_UpdateCommand = new RelayCommand(() =>
							{
								MessageBox.Show( String.Format("From ViewModel:\n\n Updated Product : ID={0}, Name={1}, Price={2}", SelectedProduct.ProductId, SelectedProduct.Name, SelectedProduct.Price));
							});
					}
					return _UpdateCommand;
				}
			}
			public MainWindowViewModel()
			{
				_products = new ObservableCollection<Product>
				{
					new Product {ProductId=1, Name="Pro1", Price=11},
					new Product {ProductId=2, Name="Pro2", Price=12},
					new Product {ProductId=3, Name="Pro3", Price=13},
					new Product {ProductId=4, Name="Pro4", Price=14},
					new Product {ProductId=5, Name="Pro5", Price=15}
				};
				
			}
			#region INotifyPropertyChanged Members
			public event PropertyChangedEventHandler PropertyChanged;
			public void RaisePropertyChanged(string propertyName)
			{
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion
		}
	}
