    public class ControlElement : UserControl
    {
          private Timer tick;
          private Point pT0;
          public ControlElement() : base()
          {
                tick = new Timer();
                tick.Interval = 30; // about 30fps
                tick.Tick += new EventHandler(tick_Tick);
          }
          void tick_Tick(object sender, EventArgs e)
          {
                // get the new point from distance and current location/destination
                this.Location = Utils.Transform(this.Location, pT0, 3);
                if ((pT0.X - this.Location.X)+(pT0.Y - this.Location.Y) <= 0)
                {
                    this.Location = pT0;
                    tick.Stop();
                    //this.Visible = true;
                }
          }
          public void Transform(Point destination)
          {
                pT0 = destination;
                //this.Visible = false;
                tick.Start();
          }
    }
