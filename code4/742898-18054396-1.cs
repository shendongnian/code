    public class MyPanel : Panel {
      Graphics g;
      public MyPanel(){
         HandleCreated += (s,e) => {
           g = panel1.CreateGraphics();
         };
      }
      protected override void WndProc(ref Message m){
         base.WndProc(ref m);
         if(m.Msg == 0xf&&g!=null)//WM_PAINT = 0xf
            g.DrawImage(im,leftTop);
      }
      //.... suppose somehow you pass im and leftTop in...
    }
