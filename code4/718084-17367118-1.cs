    //Your control has Size of Empty in this example, it just stores information of your line and is used to register the MouseMove event handler with the Form when its Parent is changed (to Form).
    public class Line : Control
    {
      public Point start { get; set; }
      public Point end { get; set; }
      public Pen pen = new Pen(Color.Red);
      protected override void OnParentChanged(EventArgs e){
        if(Parent != null){
            Parent.MouseMove -= MouseMoveParent;
            Parent.MouseMove += MouseMoveParent;
        }
      }
      private void MouseMoveParent(object sender, MouseEventArgs e){
         //the line Rectangle is specified by 4 points
         //I said that this is just for demonstrative purpose because to calculate
         //the exact 4 points (of the line Rectangle), you have to add much more code.
         Point p1 = start;
         Point p2 = new Point(p1.X + 1, p1.Y);
         Point p3 = new Point(end.X + 1, end.Y);
         Point p4 = end;
         System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
         gp.AddPolygon(new Point[]{p1,p2,p3,p4});
         Region lineRegion = new Region(gp);
         if(lineRegion.IsVisible(e.Location)){
             MessageBox.Show("Hello World");
         }
      }
    }
    public partial class Form1 : Form
    {
      public Line line = new Line() { start = new Point(50, 50), end = new Point(100, 100) };
      public Form1()
      {
        InitializeComponent();
        Controls.Add(line);
      }     
      private void Form1_Paint(object sender, PaintEventArgs e)
      {        
        e.Graphics.DrawLine(line.pen, line.start, line.end);        
      }
    }
