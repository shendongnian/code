    private void frmOpacity_Load(object sender, EventArgs e)
    {
    this.Opacity = 0;
    for (double i = -1; i <= 1; i+= 0.005)
    {
    this.Opacity = System.Math.Abs(i);
    Application.DoEvents();
    System.Threading.Thread.Sleep(5);
    }
    }
