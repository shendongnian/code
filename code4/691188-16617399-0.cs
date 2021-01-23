    public class MyEnumColorConverter : IValueConverter
	{
		private MyEnumColorConverter() { }
		 private static IValueConverter _instance;
		 public static IValueConverter Instance
		 {
			  get { return _instance ?? (_instance = new MyEnumColorConverter); }
		 }
		 // implement IValueConverter
	}
