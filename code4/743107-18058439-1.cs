    public class Form1 : Form {
       public Form1(){
          InitializeComponent();
          Load += (s,e) => {
             gridProc.AssignHandle(MainGridControl.Handle);
          };
       }
       MainGridProc gridProc = new MainGridProc();
       private void MDIMain_MdiChildActivate(object sender, EventArgs e)
       {
           if(gridProc.HitTestOn) { gridProc.HitTestOn = false; return; }
           //code is still run if HitTestOn = false
           //.......
       }   
       public class MainGridProc : NativeWindow {
          protected override void WndProc(ref Message m){
             if(m.Msg == 0x84)//WM_NCHITTEST
             {
                HitTestOn = true;
             }
             base.WndProc(ref m);
          }
          public bool HitTestOn {get;set;}
       }
    }
