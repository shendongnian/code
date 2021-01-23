       using System.Runtime.InteropServices;
        const int WM_DEVICECHANGE = 0x0219;
         // new device is pluggedin
         const int DBT_DEVICEARRIVAL = 0x8000; 
         //device is removed 
        const int DBT_DEVICEREMOVECOMPLETE = 0x8004; 
         //device is changed
        const int DBT_DEVNODES_CHANGED = 0x0007; 
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE
             {
                  //Your code here.
             }
           base.WndProc(ref m);
        }
