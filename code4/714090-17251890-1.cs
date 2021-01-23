    public class ChildForm : Form
    {
        [DllImport("user32")]
        private static extern int FlashWindowEx(FLASHWINFO flashInfo);
        struct FLASHWINFO
        {
            public int cbSize;
            public IntPtr hwnd;
            public uint flags;
            public int count;
            public int timeOut;
        }
        protected override void WndProc(ref Message m)
        {            
            if (ParentForm != null)
            {                
                ChildForm dialog = ((Form1)ParentForm).Dialog;
                if (dialog != this && dialog!=null)
                {                    
                    if (m.Msg == 0x84) //WM_NCHITTEST
                    {
                        if (MouseButtons == MouseButtons.Left)
                        {
                            Flash(dialog.Handle);
                        }
                        return;
                    }                    
                }
            }
            base.WndProc(ref m);
        }
        private void Flash(IntPtr handle)
        {
            FLASHWINFO flashInfo = new FLASHWINFO()
            {
                hwnd = handle,
                count = 9,
                cbSize = Marshal.SizeOf(typeof(FLASHWINFO)),
                flags = 3,
                timeOut = 50
            };
            FlashWindowEx(flashInfo); 
        }
        public void Flash()
        {
            Flash(Handle);
        }
        //This is to disable Tab when the Dialog is shown
        protected override bool ProcessTabKey(bool forward)
        {
            if(((Form1)ParentForm).Dialog == this) return true;
            return base.ProcessTabKey(forward);
        }
    }
    //Here is your MDI parent form
    public class Form1 : Form {
       public Form1(){
           InitializeComponent();
           IsMdiContainer = true;
           f1 = new ChildForm();
           f2 = new ChildForm();
           f1.MdiParent = this;
           f2.MdiParent = this;
           //Get MDI Client
           foreach(Control c in Controls){
              if(c is MdiClient){
                   client = c;
                   break;
              }
           }
           client.Click += ClientClicked;           
       }
       ChildForm f1, f2; 
       MdiClient client;
       public ChildForm Dialog {get;set;}
       private void ClientClicked(object sender, EventArgs e){
           if(Dialog != null) Dialog.Flash();
           else {//Show dialog, you can show dialog in another event handler, this is for demonstrative purpose
               Dialog = new ChildForm(){MdiParent = this, Visible = true};
               ActivateMdiChild(Dialog);
               //Suppose clicking on the Dialog client area will close the dialog
               Dialog.Click += (s,ev) => {
                  Dialog.Close();
               };
               Dialog.FormClosed += (s,ev) => {
                  Dialog = null;
               };
           }
       }
    }
