    public partial class Form1 : Form
    {
        int circleDiameter  = 100;
    
        public Form1()
        {
            InitializeComponent();
        }
    
         private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Point CenterPoint = new Point()
            {
                X = this.ClientRectangle.Width/2,
                Y = this.ClientRectangle.Height/2
            };
            Point topLeft = new Point()
            {
                X=(this.ClientRectangle.Width - circleDiameter) / 2,
                Y=(this.ClientRectangle.Height - circleDiameter) / 2
            };
            Point topRight = new Point()
            {
                X=(this.ClientRectangle.Width + circleDiameter) / 2,
                Y=(this.ClientRectangle.Height - circleDiameter) / 2
            };
            Point bottomLeft = new Point()
            {
                X=(this.ClientRectangle.Width - circleDiameter) / 2,
                Y=(this.ClientRectangle.Height + circleDiameter) / 2
            };
            Point bottomRight = new Point()
            {
                X=(this.ClientRectangle.Width + circleDiameter) / 2,
                Y=(this.ClientRectangle.Height + circleDiameter) / 2
            };
             e.Graphics.DrawRectangle(Pens.Red, topLeft.X, topLeft.Y, circleDiameter, circleDiameter);
             e.Graphics.DrawLine(Pens.Red, CenterPoint, topLeft);
             e.Graphics.DrawLine(Pens.Red, CenterPoint, topRight);
             e.Graphics.DrawLine(Pens.Red, CenterPoint, bottomLeft);
             e.Graphics.DrawLine(Pens.Red, CenterPoint, bottomRight);
        }
    
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    
    }
