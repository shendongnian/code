     public Form1()
            {
                InitializeComponent();
                InitializeChart();
            }
            private void InitializeChart()
            {
                tChart1.AfterDraw += new PaintChartEventHandler(tChart1_AfterDraw);
            }
    
            void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
            {
                g.Font.Size = 25; 
                g.TextOut(100, 150, "TeeChartFor.Net");
            }
