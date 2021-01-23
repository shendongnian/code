    class MessageHandler : IMessageFilter
    {
         private int WM_LBUTTONUP = 0x0202; //left mouse up
         private int WM_MBUTTONUP = 0x0208; //middle mouse up
         private int WM_RBUTTONUP = 0x0205; //right mouse up
    
         //stores the handles of the children controls (and actual user control)
         List<IntPtr> windowHandles = new List<IntPtr>();
         public MessageHandler(List<IntPtr> wnds)
         {
             windowHandles = wnds;
         }
    
    
         public bool PreFilterMessage(ref Message m)
         {
             //make sure that any click is within the user control's window or 
             //its child controls before considering it a click (required because IMessageFilter works application-wide)
             if (windowHandles.Contains(m.HWnd) && (m.Msg == WM_LBUTTONUP || m.Msg == WM_MBUTTONUP || m.Msg == WM_RBUTTONUP))
             {
                  Debug.WriteLine("Clicked");                
             }
             return false;
         }
     }
