    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
              public Form1()
              {
                   InitializeComponent();
                   
                   AXVLC.VLCPlugin2Class p = new AXVLC.VLCPlugin2Class();
                   p.addTarget("C:\\zk.m4a", null, VLCPlaylistMode.VLCPlayListInsert, 0);
                   p.play();
               }
         }
     }
