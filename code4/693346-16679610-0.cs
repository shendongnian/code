   	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.DataContext = new TypedListObservableCollection<Foo>();
			InitializeComponent();
		}
	}
	public class TypedListObservableCollection<T> : ObservableCollection<T>
		, ITypedList
	{
		public TypedListObservableCollection()
		{
		}
		PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
		{
			return TypeDescriptor.GetProperties(typeof(T), new Attribute[] { BrowsableAttribute.Yes });
		}
		string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
		{
			return typeof(T).Name;
		}
	}
	public class Foo
	{
		public string Name
		{
			get;
			set;
		}
		[Browsable(false)]
		public bool IsSelected
		{
			get;
			set;
		}
	}
