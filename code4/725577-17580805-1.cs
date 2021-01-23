    public Form1()
    {
    	InitializeComponent();
    	this.chart1.Series.Clear();
    	this.chart1.Series.Add("My Data");
    	this.chart1.Series[0].Points.AddXY(1, 1);
    	this.chart1.Series[0].Points.AddXY(2, 2);
    	this.chart1.Series[0].Points.AddXY(3, 6);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	MessageBox.Show(this.chart1.ChartAreas[0].AxisY.Maximum.ToString());
    }
