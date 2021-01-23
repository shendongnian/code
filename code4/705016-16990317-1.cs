    using System.Windows;
	using System.Windows.Controls;
	namespace WpfApplication1
	{
		public partial class MyBox : UserControl
		{
			public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(MyBox));
			public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Content", typeof(string), typeof(MyBox));
			public string Header
			{
				get { return GetValue(HeaderProperty) as string; }
				set { SetValue(HeaderProperty, value); }
			}
			public string Text
			{
				get { return GetValue(TextProperty) as string; }
				set { SetValue(TextProperty, value); }
			}
			public MyBox()
			{
				InitializeComponent();
				this.DataContext = this;
			}
		}
	}
