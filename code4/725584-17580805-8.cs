    public Form1()
    {
    	InitializeComponent();
    	this.chart1.Series.Clear();
    	this.chart1.Series.Add("My Data");
    	this.chart1.Series[0].Points.AddXY(1, 1);
    	this.chart1.Series[0].Points.AddXY(2, 2);
    	this.chart1.Series[0].Points.AddXY(3, 6);
    	this.chart1.Series.Add("My Data2");
    	this.chart1.Series[1].Points.AddXY(1, 1);
    	this.chart1.Series[1].Points.AddXY(2, 9);
    }
    
    protected override void OnShown(EventArgs e)
    {
    	base.OnShown(e);
    	this.chart1.Update();
    	MessageBox.Show(this.chart1.ChartAreas[0].AxisY.Maximum.ToString()); // returns 10
    }
