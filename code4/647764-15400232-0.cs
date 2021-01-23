    public partial class GraphChart : UserControl
    {
        private Chart chart1;
        Form1 form1;
        public GraphChart()
        {
            InitializeComponent();
        }
        public GraphChart(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;
            this.Load+=new EventHandler(GraphChart_Load);
        }
        public void SetForm( Form1 f1)
        {
            form1 = f1;
        }
        public void SetupGraph()
        {
            chart1.Series.Clear();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            this.chart1.Series.Add(series1);
            //for (int i = 0; i < 100; i++)
            //{
            series1.Points.AddXY(form1.axisX, form1.axisY);
            //}
            chart1.Invalidate();
        }
        private void GraphChart_Load(object sender, EventArgs e)
        {
            SetupGraph();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(519, 473);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // GraphChart
            // 
            this.Controls.Add(this.chart1);
            this.Name = "GraphChart";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
        }
    }
