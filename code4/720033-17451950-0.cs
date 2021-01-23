    public Form1()
    {
      InitializeComponent();
      tChart1 = new Steema.TeeChart.TChart();
      this.Controls.Add(tChart1);
      tChart1.Dock = DockStyle.Fill;
      InitializeChart();
    }
    Steema.TeeChart.Styles.LinearGauge linearGauge; 
    private void InitializeChart()
    {
      linearGauge = new LinearGauge(tChart1.Chart);
      linearGauge.Add(-50);
      linearGauge.Add(-25);
      linearGauge.Add(0);
      linearGauge.Add(25);
      linearGauge.Add(50);
    
      linearGauge.Maximum = 50;
      linearGauge.Minimum = -50;
      linearGauge.UseValueColorPalette = true;
      //InitialzieSubLines
      linearGauge.GreenLineStartValue = -50;
      linearGauge.GreenLineEndValue = 0;
      linearGauge.RedLineStartValue = 25;
      linearGauge.RedLineEndValue = 50;
      linearGauge.Value = -25; 
      timer1 = new Timer();
      timer1.Start(); 
      timer1.Tick +=timer1_Tick;
    
    }
