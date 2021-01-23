    public partial class Form1 : Form
        {
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
                this.panel1.Paint += new PaintEventHandler(PanelPaint);
                this.panel1.Invalidate();
            }
        }
