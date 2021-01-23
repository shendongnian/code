    public Form1()
    {
      InitializeComponent();
      InitializeChart();
    }
    
    private void InitializeChart()
    {
      bool automatic = true;
    
      SetChart(new[] { 0.5685, 0.7141, 0.7301, 0.748, 0.7847, 1.2127 }, automatic);
      SetChart(new[] { 0.5686, 0.7141, 0.7301, 0.748, 0.7847, 1.2127 }, automatic);
    
      tChart1.Axes.Left.SetMinMax(0.55, 1.25);
    }
    
    private void SetChart(double[] values, bool auto)
    {
      var box = new Steema.TeeChart.Styles.Box(tChart1.Chart);
      box.Add(tChart1.Series.Count, values);
    
      if (auto)
      {
        box.ReconstructFromData();
    
        listBox1.Items.Add("Series: " + box.Title.ToString());
        listBox1.Items.Add("Median: " + box.Median.ToString());
        listBox1.Items.Add("Quartile1: " + box.Quartile1.ToString());
        listBox1.Items.Add("Quartile3: " + box.Quartile3.ToString());
        listBox1.Items.Add("InnerFence1: " + box.InnerFence1.ToString());
        listBox1.Items.Add("InnerFence3: " + box.InnerFence3.ToString());
        listBox1.Items.Add("OuterFence1: " + box.OuterFence1.ToString());
        listBox1.Items.Add("OuterFence3: " + box.OuterFence3.ToString());
        listBox1.Items.Add("AdjacentPoint1: " + box.AdjacentPoint1.ToString());
        listBox1.Items.Add("AdjacentPoint3: " + box.AdjacentPoint3.ToString());
        listBox1.Items.Add("-------------------------");
      }
      else
      {
        box.UseCustomValues = !auto;
    
        box.Median = 0.73905;
        box.OuterFence1 = 0.0357;
        box.OuterFence3 = 1.5337;
    
        box.InnerFence1 = 0.3567;
        box.InnerFence3 = 1.2127;
    
        box.Quartile1 = 0.6777;
        box.Quartile3 = 0.8917;
    
        box.AdjacentPoint1 = box.YValues[0];
        box.AdjacentPoint3 = 1.2127;
    
        box.Median = 0.73905;
      }
    }
