    public partial class Form1 : Form
    {
        public int axisX = 100;
        public int axisY = 100;
        GatherLinks.GraphChart graphChart1;
        public Form1()
        {
            InitializeComponent();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            graphChart1 = new GatherLinks.GraphChart();
            this.Controls.Add(graphChart1);
            graphChart1.SetForm(this);
            graphChart1.SetupGraph();
        }
       
    }
