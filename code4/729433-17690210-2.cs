    public class ImageControl : Control {
       public ImageControl(){
          SetStyle(ControlStyles.Opaque, true);
       }
       public Image Image {get;set;}
       protected override CreateParams CreateParams {
          get {
              CreateParams cp = base.CreateParams;
              cp.ExStyle |= 0x20;
              return cp;
          }
       }
       protected override void OnPaint(PaintEventArgs e){
          if(Image != null) e.Graphics.DrawImage(Image, Point.Empty);
       }
    }
