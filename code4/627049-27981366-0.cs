		public static readonly DependencyProperty MyContentProperty = DependencyProperty.Register(
			"MyContent", typeof(string), typeof(MyTextEditor), new PropertyMetadata("", OnMyContentChanged));
		private static void OnMyContentChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var control = (MyTextEditor)sender;
			if (string.Compare(control.MyContent, e.NewValue.ToString()) != 0)
			{
				//avoid undo stack overflow
				control.MyContent = e.NewValue.ToString();
			}
		}
		public string MyContent
		{
			get
			{
				string result = Text;
				return result;
			}
			set
			{
				Text = value;
			}
		}
		protected override void OnTextChanged(EventArgs e)
		{
			SetCurrentValue(MyContentProperty, Text);
			base.OnTextChanged(e);
		}
