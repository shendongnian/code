    public partial class Form1 : Form
    {
        private bool _paintWired;
        public Form1()
        {
            InitializeComponent();
        }
        private void PanelPaint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.panel1.CreateGraphics())
            {
                g.FillRectangle(Brushes.Black, this.panel1.Bounds);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!_paintWired)
            {
                this.panel1.Paint += new PaintEventHandler(PanelPaint);
                _paintWired = true;
            }
            
            this.panel1.Invalidate();
        }
    }
