    public RussianCanvas(Canvas source) : base(){
			Margin = source.Margin;
			Style = source.Style;
			Height = source.Height;
			Width = source.Width;
			Background = source.Background;
			VerticalAlignment = source.VerticalAlignment;
			HorizontalAlignment = source.HorizontalAlignment;
			doubleClickStarted = false;
			doubleClickTimer = new DispatcherTimer();
			doubleClickTimer.Interval = new TimeSpan(DOUBLE_CLICK_INTERVAL);
			doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);
			MouseUp += new MouseButtonEventHandler(mouseUpReaction);
		}
