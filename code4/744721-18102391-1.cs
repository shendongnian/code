    public class Form1 : Form { 
       public Form1(){
          InitializeComponent();
          proc = new LiveDeviceSourceProc();
          Load += (s,e) => {            
             proc.AssignHandle(yourLiveDeviceSource.Handle);
          }; 
          proc.Click += (s,e) => {
             //you can also process your code here
          };
       }
       LiveDeviceSourceProc proc;
       public class LiveDeviceSourceProc : NativeWindow {
         protected override void WndProc(ref Message m){
            if(m.Msg == 0x202)//WM_LBUTTONUP   <=> Left Mouse Click
            {
                //process your code here
                if(Click != null) Click(this,EventArgs.Empty);
            }
            base.WndProc(ref m);
         }
         public event EventHandler Click;
       }
    }
