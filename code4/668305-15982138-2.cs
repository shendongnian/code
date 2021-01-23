    public partial class Form1 : Form
    {
       private Point MouseDownLocation;
     
       public Form1()
       {
          InitializeComponent();
          this.DoubleBuffered = true;
          timer1.Start(); // add timer to the form
       }
       Rectangle rec = new Rectangle(0, 0, 0, 0);
       protected override void OnPaint(PaintEventArgs e)
       {
           e.Graphics.FillRectangle(Brushes.DeepSkyBlue, rec);
       }
       private void timer1_Tick(object sender, EventArgs e)
       {
           Refresh();
       }
      
      
      protected override void OnMouseMove(MouseEventArgs e)
      {
          if (e.Button == MouseButtons.Left)
          {
             rec.Width = e.X - rec.X;
             rec.Height = e.Y - rec.Y;
          }
          else if (e.Button == MouseButtons.Right)
          {
            rec.X = e.X - MouseDownLocation.X;
            rec.Y = e.Y - MouseDownLocation.Y;
          }
      }
       protected override void OnMouseUp(object sender, MouseEventArgs e)
       {
           if (e.Button == MouseButtons.Right)
              MouseDownLocation = e.Location;
       }
     }
