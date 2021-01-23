    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyTreeView : TreeView
    {
    	public TreeView RealTreeView;
    	public MyTreeView()
    	{
    		RealTreeView = new TreeView();
    		RealTreeView.Dock = DockStyle.Fill;
    		Controls.Add(RealTreeView);
    	}
    	enum WM
    	{
    		NOTIFY = 78
    	}
    	enum NM : uint
    	{
    		FIRST = 0,
    		NM_CLICK = unchecked(FIRST - 2),
    		NM_CUSTOMDRAW = unchecked(FIRST - 12),
    		NM_DBLCLK = unchecked(FIRST - 3),
    		NM_KILLFOCUS = unchecked(FIRST - 8),
    		NM_RCLICK = unchecked(FIRST - 5),
    		NM_RDBLCLK = unchecked(FIRST - 6),
    		NM_RETURN = unchecked(FIRST - 4),
    		NM_SETCURSOR = unchecked(FIRST - 17),
    		NM_SETFOCUS = unchecked(FIRST - 7)
    	}
    
    	[StructLayout(LayoutKind.Sequential)]
    	struct NMHDR {
    		public IntPtr hwndFrom;
    		public UIntPtr idFrom;
    		public uint code;
    	}
    
    	protected override void WndProc(ref Message m)
    	{
    		base.WndProc(ref m);
    		if (m.Msg == (int)WM.NOTIFY)
    		{
    			uint code;
    			unsafe
    			{
    				var nmhdr = (NMHDR*)m.LParam.ToPointer();
    				code = nmhdr->code;
    			}
    			NM nmCode = (NM)code;
    			Console.WriteLine("WM_NOTIFY " + nmCode);
    		}
    	}
    }
    
    public class MyGuiClass
    {
    	public static void Main()
    	{
    		Form f = new Form();
    		var tv = new MyTreeView();
    		tv.RealTreeView.Nodes.Add("zero").Nodes.Add("sub-zero");
    		tv.RealTreeView.Nodes.Add("one");
    		tv.RealTreeView.Nodes.Add("two");
    		tv.RealTreeView.Nodes.Add("three");
    		tv.Dock = DockStyle.Fill;
    		f.Controls.Add(tv);
    		Application.Run(f);
    	}
    }
