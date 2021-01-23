	public partial class MainWindow : Window
	{
		public static readonly DependencyProperty MyPersonProperty;
		static MainWindow()
		{
			MyPersonProperty = DependencyProperty.Register("MyPerson", typeof(Person), typeof(MainWindow));
		}
		Person MyPerson
		{
			set
			{
				SetValue(MyPersonProperty,value);
			}
			get
			{
				return GetValue(MyPersonProperty) as Person;
			}
		}
		public MainWindow()
		{
			MyPerson = new Person();
			
			InitializeComponent();
		}
	}
