    public class Line : Control
    {    
      Color lineColor = Color.Red;
      public Color LineColor {
          get { return lineColor;}
          set {
              lineColor = value;
              BackColor = value;
          }
      }
      public Line(){
         Height = 1;//Default thickness
         Width = 100;//Default length
         BackColor = lineColor;
      }
      //for the case you want to draw yourself, add code in this method
      protected override void OnPaint(PaintEventArgs e){
           base.OnPaint(e);
           //your code
      }
    }
    //use it
    Line line = new Line(){Left = 50, Top = 50};
    line.MouseEnter += new EventHandler(line_MouseEnter);
