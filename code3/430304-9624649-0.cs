	public class BindingBehavior : Behavior<DependencyObject> {
		public static readonly DependencyProperty InProperty = DependencyProperty.Register(
			"In",
			typeof(object),
			typeof(BindingBehavior),
			new FrameworkPropertyMetadata(null, (d, e) => ((BindingBehavior) d).OnInPropertyChanged(e.NewValue)));
		public static readonly DependencyProperty OutProperty = DependencyProperty.Register(
			"Out",
			typeof(object),
			typeof(BindingBehavior),
			new FrameworkPropertyMetadata(null));
		// Bind OneWay
		public object In {
			get { return GetValue(InProperty); }
			set { SetValue(InProperty, value); }
		}
		// Bind OneWayToSource
		public object Out {
			get { return GetValue(OutProperty); }
			set { SetValue(OutProperty, value); }
		}
		private void OnInPropertyChanged(object value) {
			Out = value;
		}
		protected override Freezable CreateInstanceCore() {
			return new BindingBehavior();
		}
	}
