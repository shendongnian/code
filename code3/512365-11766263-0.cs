    // Put this in your constructor, or use VisualStudio to create the method for you
    this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint_Method);
    private void paint_Method(object sender, PaintEventArgs e)
    { 
         gg = e.Graphics;
         p3 = new Pen(Color.Blue,5);
         b1 = new SolidBrush(Color.Red);
         p2 = new Pen(Color.Red);
         Font f=new Font("Arial",16);
         float ox = this.ClientSize.Width / 2;
         float oy = this.ClientSize.Height / 2;
         gg.DrawLine(p3, ox - 500, oy, ox + 500, oy);
         gg.DrawLine(p3, ox, oy + 300, ox, oy - 300);
         gg.DrawString("Argument", f, b1, ox - 100, oy - 200);
         gg.DrawString("<----f(Argument)---->", f, b1, ox + 100, oy + 100);
         for (int i = 0; i < 1000; i++)
         {
             double tem1 = graphValuesCal();
             double temp2 = functionCal();
             gg.FillEllipse(b1, ox + (float)tem1/2,oy-20*(float)temp2, 5f, 5f);
             // Thread.Sleep(10);
         }
    }
