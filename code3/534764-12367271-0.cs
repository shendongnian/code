    public class YourFilter : IMessageFilter
	{
        public event EventHandler F2Pressed = delegate { };
		
		private const Int32 WM_KEYDOWN = 0x0100;
		
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg != WM_KEYDOWN)
				return false;
			
			if ((Keys)m.WParam==Keys.F2)
				F2Pressed(this, new EventArgs());
			return false;
		}
	}
