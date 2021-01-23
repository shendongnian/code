    public partial class meClass : Form
    {
      private System.Windows.Forms.Timer t;
      private int count;
      private DateTime start;
      public meClass()
      {
         t = new Timer();
         t.Interval = 50;
         t.Tick += new EventHandler(t_Tick);
         count = 0;
         start = DateTime.Now;
         t.Start();
      }
      void t_Tick(object sender, EventArgs e)
      {
         if (count++ >= 10 || (DateTime.Now - start).TotalSeconds > 10)
         {
            t.Stop();
         }
         // do your stuff
      }
    }
