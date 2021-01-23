    		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(MyClass), new PropertyMetadata(string.Empty));
		    public string Text
		    {
			    get { return (string)GetValue(TextProperty); }
			    set { SetValue(TextProperty, value); }
		    }
