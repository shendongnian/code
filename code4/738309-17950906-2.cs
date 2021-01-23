    public class FormWndProc : NativeWindow {
       protected override void WndProc(ref Message m){
          if(m.Msg == 0x18&&m.WParam != IntPtr.Zero)//WM_SHOWWINDOW = 0x18
          {
             //your code here
             //you can use m.HWnd to get the Handle of the form
          }
          base.WndProc(ref m);
       }
    }
    //use the class
    //suppose you want to execute the code before showing the form1, form2, form3
    new FormWndProc().AssignHandle(form1.Handle);
    new FormWndProc().AssignHandle(form2.Handle);
    new FormWndProc().AssignHandle(form3.Handle);
    //you can save the instance of FormWndProc to call the ReleaseHandle() method later if you don't want to insert code before showing the form.
