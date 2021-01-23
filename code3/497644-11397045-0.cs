	public class HtmlTableCellPH : HtmlTableCell
	{
		public HtmlTableCellPH()
		{
		}
		public HtmlTableCellPH(string tagName)
			: base(tagName)
		{
		}
		public override void RenderControl(HtmlTextWriter writer)
		{
			this.RenderChildren(writer);
		}
	}
