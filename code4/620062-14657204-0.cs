    private int loopVar = 0;
    public void Form_Load()
    {
        // Start 100ms after form load.
        timer1.Interval = 100;
        timer1.Enabled = true;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
       timer1.Enabled = false;
       //  My Code Here
       loopVar++;
       if (loopVar < Max_Step)
       {
          // Come back to the _tick after 60 seconds.
          timer1.Interval = 60000;
          timer1.Enabled = true;
          
       }
    }
