    using System.Runtime.InteropServices; //to DllImport
     public int WM_SYSCOMMAND = 0x0112;
     public int SC_MONITORPOWER = 0xF170; //Using the system pre-defined MSDN constants    
     that    can be used by the SendMessage() function .
     [DllImport("user32.dll")]
     private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
    //To call a DLL function from C#, you must provide this declaration .
      private void button1_Click(object sender, System.EventArgs e)
      {
       SendMessage( this.Handle.ToInt32() , WM_SYSCOMMAND , SC_MONITORPOWER ,2 );//DLL    
       function
       }
