    private void Form1_Load(object sender, EventArgs e)
    {
       System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
       timer.Interval = 10;
       timer.Tick += new EventHandler(t_Tick);
       timer.Start();
    }
      void OnTick(object sender, EventArgs e)
      {
         // Your code
      }
