    protected override void WndProc(ref Message m)
    {
         base.WndProc(ref m);
    
         if (m.Msg == WM_SETTEXT)
         {
               // Call to your logic here
         }
    }
