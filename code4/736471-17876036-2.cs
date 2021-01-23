    public class Form1 : Form {
        public Form1(){
          InitializeComponent();
          //Suppose you want to disable scroll in Panel1 of your SplitContainer when Control key is pressed
          new PanelWndProc().AssignHandle(splitContainer1.Panel1.Handle);          
        }
        public class PanelWndProc : NativeWindow
        {
          protected override void WndProc(ref Message m)
          {
            if (m.Msg == 0x20a && Control.ModifierKeys == Keys.Control) return;
            base.WndProc(ref m);
          }
        }
    }
