	public class MyTreeView : TreeView
	{
		#region Constructors
		public MyTreeView()
		{
		}
		#endregion
		#region Overrides
		protected override void WndProc(ref Message m)
		{
			// Suppress WM_LBUTTONDBLCLK on checkbox
			if (m.Msg == 0x0203 && CheckBoxes && IsOnCheckBox(m))
			{
				m.Result = IntPtr.Zero;
			}
			else
			{
				base.WndProc(ref m);
			}
		}
		#endregion
		#region Double-click check
		private int GetXLParam(IntPtr lParam)
		{
			return lParam.ToInt32() & 0xffff;
		}
		private int GetYLParam(IntPtr lParam)
		{
			return lParam.ToInt32() >> 16;
		}
		private bool IsOnCheckBox(Message m)
		{
			int x = GetXLParam(m.LParam);
			int y = GetYLParam(m.LParam);
			TreeNode node = GetNodeAt(x, y);
			if (node == null)
				return false;
			int iconWidth = ImageList == null ? 0 : ImageList.ImageSize.Width;
			int right = node.Bounds.Left - 4 - iconWidth;
			int left = right - CHECKBOX_WIDTH;
			return left <= x && x <= right;
		}
		const int CHECKBOX_WIDTH = 12;
		#endregion
	
