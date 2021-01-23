    Steema.TeeChart.Styles.Points points1; 
    Steema.TeeChart.TChart tChart1;
    Random rnd; 
    public Form1()
    {
        InitializeComponent();
 
        tChart1 = new Steema.TeeChart.TChart();
        this.Controls.Add(tChart1);
        tChart1.Aspect.View3D = false;
        tChart1.Height = 400;
        tChart1.Width = 500;
        tChart1.Dock = DockStyle.Bottom;
        points1 = new Steema.TeeChart.Styles.Points(tChart1.Chart);
        rnd = new Random();
        InitializeChart();
    }
    private void InitializeChart()
    {
   
        for (int i = 0; i < 128; i++)
        {
            points1.Add(i, rnd.Next(100)); 
           
        }
        tChart1.Refresh();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 128; i++)
        {
            points1.XValues[i] = i+1;
            points1.YValues[i] = rnd.Next(100);
          
        }
        points1.BeginUpdate();
        points1.EndUpdate();
                 
    }
