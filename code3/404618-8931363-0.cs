    public class myScrollingListBox : ListBox 
    {
      // Event declaration
      public delegate void myScrollingListBoxDelegate(object Sender, myScrollingListBoxScrollArgs e);
      public event myScrollingListBoxDelegate Scroll;
      // WM_VSCROLL message constants
      private const int WM_VSCROLL = 0x0115;
      private const int SB_THUMBTRACK = 5;
      private const int SB_ENDSCROLL = 8;
    
      protected override void WndProc(ref Message m) 
      {
        // Trap the WM_VSCROLL message to generate the Scroll event
        base.WndProc(ref m);
        if (m.Msg == WM_VSCROLL)
    	{
          int nfy = m.WParam.ToInt32() & 0xFFFF;
          if (Scroll != null && (nfy == SB_THUMBTRACK || nfy == SB_ENDSCROLL))
            Scroll(this, new myScrollingListBoxScrollArgs(this.TopIndex, nfy == SB_THUMBTRACK));
        }
      }
      public class myScrollingListBoxScrollArgs 
      {
        // Scroll event argument
        private int mTop;
        private bool mTracking;
        public myScrollingListBoxScrollArgs(int top, bool tracking)
    	{
          mTop = top;
          mTracking = tracking;
        }
        public int Top
    	{
          get { return mTop; }
        }
        public bool Tracking
    	{
          get { return mTracking; }
        }
      }
    }
