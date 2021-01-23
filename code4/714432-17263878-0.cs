    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Hide();
            fr2.AddPoint("student's grad", new Point( 0,0));
            fr2.ShowDialog();
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void AddPoint( string series, Point chartPoint)
        {
            chart1.Series["student's grad"].Points.AddXY(chartPoint.X, chartPoint.Y);
        }
    }
