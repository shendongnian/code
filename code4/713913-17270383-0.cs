    [StructLayout(LayoutKind.Sequential)]
    struct CHARRANGE
    {
       public int cpMin;
       public int cpMax;
    };
    
    [StructLayout(LayoutKind.Sequential)]
    struct NMHDR
    {
       public IntPtr hwndFrom;
       public IntPtr idFrom;
       public int code;
    };
    
    [StructLayout(LayoutKind.Sequential)]
    struct ENLINK
    {
       public NMHDR nmhdr;
       public int msg;
       public IntPtr wParam;
       public IntPtr lParam;
       public CHARRANGE chrg;
    };
    
    public class MyForm : Form
    {
       // ... other code ...
       
       protected override void WndProc(ref Message m)
       {
          const int WM_NOTIFY    = 0x004E;
          const int EN_LINK      = 0x070B;
          const int WM_SETCURSOR = 0x0020;
    
          if (m.Msg == WM_NOTIFY)
          {
             NMHDR nmhdr = (NMHDR)m.GetLParam(typeof(NMHDR));
             if (nmhdr.code == EN_LINK)
             {
                ENLINK enlink = (ENLINK)m.GetLParam(typeof(ENLINK));
                if (enlink.msg == WM_SETCURSOR)
                {
                    // Set the result to indicate this message has been handled,
                    // and return without calling the default window procedure.
                    m.Result = (IntPtr)1;
                    return;
                }
             }
          }
          base.WndProc(ref m);
       }
    }
