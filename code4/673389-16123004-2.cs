    public static class PropertyToInvalidateBehaviour {
		static Lazy<DispatcherTimer> LazyTimer = new Lazy<DispatcherTimer>(() => {
			DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
			timer.Start();
			return timer;
		});
		static ConcurrentDictionary<int, EventHandler> Events = new ConcurrentDictionary<int, EventHandler>();
		public static DependencyProperty GetPropertyToInvalidate(DependencyObject obj) {
			return (DependencyProperty)obj.GetValue(PropertyToInvalidateProperty);
		}
		public static void SetPropertyToInvalidate(DependencyObject obj, DependencyProperty value) {
			obj.SetValue(PropertyToInvalidateProperty, value);
		}
		public static readonly DependencyProperty PropertyToInvalidateProperty = DependencyProperty.RegisterAttached("PropertyToInvalidate",
		  typeof(DependencyProperty), typeof(PropertyToInvalidateBehaviour),
		  new UIPropertyMetadata(null, OnPropertyToInvalidateChanged));
		private static void OnPropertyToInvalidateChanged(object sender, DependencyPropertyChangedEventArgs e) {
			var propertyToInvalidate = e.NewValue as DependencyProperty;
			EventHandler oldEvent;
			if (Events.TryRemove(e.Property.GetHashCode(), out oldEvent)) {
				LazyTimer.Value.Tick -= oldEvent;
			}
			if (null == propertyToInvalidate) {
				return;
			}
			var doUpdate = new EventHandler((s, args) => {
				BindingExpression binding = BindingOperations.GetBindingExpression(sender as DependencyObject, propertyToInvalidate);
				binding.UpdateTarget();
			});
			Events.TryAdd(e.Property.GetHashCode(), doUpdate);
			LazyTimer.Value.Tick += doUpdate;
		}
	}
