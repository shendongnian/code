    public class Form1 : Form {
      ///....
      protected override void WndProc(ref Message m){
          if(m.Msg == 0x18)//WM_SHOWWINDOW = 0x18
          {
             //your code here
             //you can use m.HWnd to get the Handle of the form
          }
          base.WndProc(ref m);
      }
    }
    //This way you don't need the class FormWndProc as defined above.
