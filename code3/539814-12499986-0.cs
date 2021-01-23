	public class ButtonWedge : Button
	{
		protected override void OnClick(System.EventArgs e)
		{
			Debugger.Break();
			base.OnClick(e);
		}
	}
