	[ToolboxItem(true)]
	public class MyTabControl : TabControl
	{
		public event ControlEventHandler TabAdded;
		public event ControlEventHandler TabRemoved;
		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new ControlCollection(this);
		}
		protected virtual void OnTabAdded(ControlEventArgs e)
		{
			var @event = TabAdded;
			if (@event != null)
				@event.Invoke(this, e);
		}
		protected virtual void OnTabRemoved(ControlEventArgs e)
		{
			var @event = TabRemoved;
			if (@event != null)
				@event.Invoke(this, e);
		}
		public new class ControlCollection : TabControl.ControlCollection
		{
			public ControlCollection(MyTabControl owner)
				: base(owner)
			{ }
			public override void Add(Control value)
			{
				base.Add(value);
				((MyTabControl)Owner).OnTabAdded(new ControlEventArgs(value));
			}
			public override void Remove(Control value)
			{
				base.Remove(value);
				((MyTabControl)Owner).OnTabRemoved(new ControlEventArgs(value));
			}
		}
	}
