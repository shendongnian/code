	private void treeView_DragOver(object sender, DragEventArgs e)
	{
		TreeView senderTree = sender as TreeView;
		TreeNode destinationNode;
		TreeNode newNode = GetDragTreeNode(out destinationNode, sender, e);
		if (newNode == null)
		{
			e.Effect = DragDropEffects.None;
			return;
		}
		int scrollDetectRangeU = 10;
		int scrollDetectRangeL = 10;
		int scrollDetectRangeB = 10 + 20;
		int scrollDetectRangeR = 10 + 20;
		Point treeCoord = CoordToTreeCoord(senderTree, e);
		if (treeCoord.Y < scrollDetectRangeU 
			&& (destinationNode == null || destinationNode.PrevVisibleNode != null))
		{
			SendMessage(senderTree.Handle, WindowsMessages.WM_VSCROLL, ScrollBarCommands.SB_LINEUP, IntPtr.Zero);    //scroll up
			Thread.Sleep(10);   //slow down the scrolling a bit
		}
		else if (treeCoord.Y >= senderTree.Height - scrollDetectRangeB 
			&& (destinationNode == null || destinationNode.NextVisibleNode != null))
		{
			SendMessage(senderTree.Handle, WindowsMessages.WM_VSCROLL, ScrollBarCommands.SB_LINEDOWN, IntPtr.Zero);    //scroll down
			Thread.Sleep(10);   //slow down the scrolling a bit
		}
		if (treeCoord.X < scrollDetectRangeL)
		{
			SendMessage(senderTree.Handle, WindowsMessages.WM_HSCROLL, ScrollBarCommands.SB_LINELEFT, IntPtr.Zero);     //scroll left
		}
		else if (treeCoord.X >= senderTree.Width - scrollDetectRangeR)
		{
			SendMessage(senderTree.Handle, WindowsMessages.WM_HSCROLL, ScrollBarCommands.SB_LINERIGHT, IntPtr.Zero);     //scroll right
		}
	}
	
	private static TreeNode GetDragTreeNode(out TreeNode destinationNode, object sender, DragEventArgs e)
	{
		TreeNode newNode = null;
		if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))  
		{
			newNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
		}
		if (newNode != null)
		{
			destinationNode = CoordToTreeNode(sender, e);    
		}
		else
		{
			destinationNode = null;
		}
		return newNode;
	}
	
	public static Point CoordToTreeCoord(object senderTree, DragEventArgs e)
	{
		return CoordToTreeCoord(senderTree as TreeView, e.X, e.Y, true);
	}
	public static Point CoordToTreeCoord(TreeView senderTree, int x, int y, bool usePointToClient)
	{
		Point pt = usePointToClient ? senderTree.PointToClient(new Point(x, y)) : new Point(x, y);
		return pt;
	}
	public static TreeNode CoordToTreeNode(object senderTree, DragEventArgs e)
	{
		return CoordToTreeNode(senderTree as TreeView, e.X, e.Y, true);
	}
	public static TreeNode CoordToTreeNode(TreeView senderTree, int x, int y, bool usePointToClient)
	{
		Point pt = CoordToTreeCoord(senderTree, x, y, usePointToClient);
		TreeNode destinationNode = senderTree.GetNodeAt(pt);
		return destinationNode;
	}
	[DllImport("user32.dll")]
	static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, ScrollBarCommands wParam, IntPtr lParam);  
        
    public enum ScrollBarCommands : int
    {
        SB_LINEUP = 0,
        SB_LINELEFT = 0,
        SB_LINEDOWN = 1,
        SB_LINERIGHT = 1,
        SB_PAGEUP = 2,
        SB_PAGELEFT = 2,
        SB_PAGEDOWN = 3,
        SB_PAGERIGHT = 3,
        SB_THUMBPOSITION = 4,
        SB_THUMBTRACK = 5,
        SB_TOP = 6,
        SB_LEFT = 6,
        SB_BOTTOM = 7,
        SB_RIGHT = 7,
        SB_ENDSCROLL = 8
    }
    public static class WindowsMessages
    {
        // Windows messages 
        public const int WM_PAINT = 0x000F;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_LBUTTONUP = 0x0202;
        // ScrollBar types 
        public const int SB_HORZ = 0;
        public const int SB_VERT = 1;
        // ScrollBar interfaces 
        public const int SIF_TRACKPOS = 0x10;
        public const int SIF_RANGE = 0x01;
        public const int SIF_POS = 0x04;
        public const int SIF_PAGE = 0x02;
        public const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;
        // ListView messages 
        public const uint LVM_SCROLL = 0x1014;
        public const int LVM_FIRST = 0x1000;
        public const int LVM_SETGROUPINFO = (LVM_FIRST + 147);
    }
	
 
