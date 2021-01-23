    public partial class Form1 : Form
    {
        int circleDiameter  = 100;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawCircleInMiddleOfForm(e);
        }
    
        private void DrawCircleInMiddleOfForm(PaintEventArgs e)
        {
            Point topLeft = new Point((this.ClientRectangle.Width - circleDiameter) / 2, (this.ClientRectangle.Height - circleDiameter) / 2);
            e.Graphics.DrawRectangle(Pens.Red, topLeft.X, topLeft.Y, circleDiameter, circleDiameter);
        }
    
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    
    }
