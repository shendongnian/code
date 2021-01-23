    public class Form1 {
      public Form1(){
          InitializeComponent();
          WindowState = FormWindowState.Maximized;
          MaximizeBox = false;        
      }
      bool hitControlButtons;
      protected override void WndProc(ref Message m)
      {
         if ((!hitControlButtons) && (m.Msg == 0xa3 || m.Msg == 0xa1))//WM_NCLBUTTONDBLCLK and WM_NCLBUTTONDOWN
         {                
            return;
         }
         if (m.Msg == 0xA0)//WM_NCMOUSEMOVE
         {
            int wp = m.WParam.ToInt32();                
            hitControlButtons = wp == 8 || wp == 20 || wp == 9;//Mouse over MinButton, CloseButton, MaxButton                               
         }
         base.WndProc(ref m);            
      }
    }
