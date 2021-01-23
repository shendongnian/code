        public Form1()
        {
            InitializeComponent();
            InitializeChart();
        }
        Steema.TeeChart.Styles.ColorGrid grid; 
        Steema.TeeChart.Styles.Points points;
        private void InitializeChart()
        {
            grid = new ColorGrid(tChart1.Chart);
            points = new Points(tChart1.Chart);
            tChart1.Aspect.View3D = false;
            Random rnd = new Random();
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    grid.Add(i, rnd.Next(255), j);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                double x = rnd.Next(100);
                double y = rnd.Next(100);
                points.Add(x, y);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
           
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    grid.YValues[j + 128 * i] = rnd.Next(255);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                points.SetNull(i);
            }
            for (int i = 0; i < rnd.Next(20); i++)
            {
                points.XValues[i] = rnd.Next(128);
                points.YValues[i] = rnd.Next(128);
                points.SetNull(i, false);
            }
            points.TreatNulls = TreatNullsStyle.Ignore;
        }
