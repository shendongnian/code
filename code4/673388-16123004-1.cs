	public static class TimeAgoBehaviour {
		static Lazy<DispatcherTimer> LazyTimer = new Lazy<DispatcherTimer>(() => {
			DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
			timer.Start();
			return timer;
		});
		static ConcurrentDictionary<int, EventHandler> Events = new ConcurrentDictionary<int, EventHandler>();
		public static DateTime GetTimeAgo(ContentControl obj) {
			return (DateTime)obj.GetValue(TimeAgoProperty);
		}
		public static void SetTimeAgo(ContentControl obj, DependencyProperty value) {
			obj.SetValue(TimeAgoProperty, value);
		}
		public static readonly DependencyProperty TimeAgoProperty = DependencyProperty.RegisterAttached("TimeAgo",
			typeof(DateTime), typeof(TimeAgoBehaviour),
			new UIPropertyMetadata(DateTime.UtcNow, OnTimeAgoChanged));
		private static void OnTimeAgoChanged(object sender, DependencyPropertyChangedEventArgs e) {
			var newDate = (DateTime)e.NewValue;
			EventHandler oldEvent;
			if (Events.TryRemove(sender.GetHashCode(), out oldEvent)) {
				LazyTimer.Value.Tick -= oldEvent;
			}
			if (DateTime.MinValue == newDate) {
				return;
			}
			var doUpdate = new EventHandler((s, args) => {
				ContentControl control = sender as ContentControl;
				control.Content = TimeAgoConverter.GetTimeAgo(newDate);
			});
			doUpdate(sender, new EventArgs());
			Events.TryAdd(sender.GetHashCode(), doUpdate);
			LazyTimer.Value.Tick += doUpdate;
		}
	}
