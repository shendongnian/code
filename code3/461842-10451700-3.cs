        public static readonly DependencyProperty IBackgroundProperty = DependencyProperty.Register("IBackground", typeof(Rectangle), typeof(NameOfYourUserControl));
		public Rectangle IBackground
		{
			get { return (Rectangle)GetValue(IBackgroundProperty); }
			set { SetValue(IBackgroundProperty, value); }
		}
