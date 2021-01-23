		public class MyItemClass : DependencyObject
		{
			//MyItemText Dependency Property
			public string MyItemText
			{
				get { return (string)GetValue(MyItemTextProperty); }
				set { SetValue(MyItemTextProperty, value); }
			}
			public static readonly DependencyProperty MyItemTextProperty =
				DependencyProperty.Register("MyItemText", typeof(string), typeof(MyItemClass), new UIPropertyMetadata("---"));
		}
