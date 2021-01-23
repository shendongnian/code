	public class MongoDataPanel : Panel
	{
		[DllImport("user32.dll")]
		static public extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
		private const int SB_HORZ = 0;
		private const int SB_VERT = 1;
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			if (this.Parent != null)
			{
				if (this.Parent.Width > this.PreferredSize.Width - 10)
				{
					try
					{
						ShowScrollBar(this.Handle, SB_HORZ, false);
					}
					catch (Exception e) { }
				}
			}
		}
	}
