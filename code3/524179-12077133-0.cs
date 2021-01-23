    public partial class Form1 : Form
    {
        Color currentColor = Color.Green;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentColor == Color.Yellow)
                currentColor = Color.Green;
            else
                currentColor = Color.Yellow;
            tabControl1.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (timer1.Enabled && e.Index == 1)
            {
                e.Graphics.FillRectangle(new SolidBrush(currentColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
            }
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
        }
    }
