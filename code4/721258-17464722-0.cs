    public class MyListView : ListView {
       public override Color BackColor {
          get { return base.BackColor;}
          set {
            base.BackColor = value;
            if(BackgroundImage == null){
               Bitmap bm = new Bitmap(1,1);
               bm.SetPixel(0,0,value);
               BackgroundImage = bm;
               BackgroundImageTiled = true;
            }
          }
       }
       public override Image BackgroundImage {
          get { return base.BackgroundImage; }
          set {
              base.BackgroundImage = value;
              if(value == null){
                Bitmap bm = new Bitmap(1,1);
                bm.SetPixel(0,0,BackColor);
                BackgroundImage = bm;
                BackgroundImageTiled = true;  
              }
          }
       }
    }
