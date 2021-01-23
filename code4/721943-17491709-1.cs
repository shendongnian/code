	public partial class OnScreenKeyboard : Form
	{
		private const int WS_EX_NOACTIVATE = 0x08000000;
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams p = base.CreateParams;
				p.ExStyle |= WS_EX_NOACTIVATE;
				return p;
			}
		}
		
	}
