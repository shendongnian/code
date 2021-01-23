    public partial class Form1 : Form
    {
        bool[,] selected = new bool[2,12];
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int a, b;
            for (a = 0; a <= 1; a++)
            {
                for (b = 0; b < 12; b++)
                {
                    if (selected[a, b])
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), b * 40, a * 40, 40, 40);
                        
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.White ), b * 40, a * 40, 40, 40);
                    }
                    e.Graphics.DrawRectangle(new Pen(Color.Black), b * 40, a * 40, 40, 40);
                }
            } 
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int xPos, yPos;
            xPos = e.X / 40;
            yPos = e.Y / 40;
            if ((xPos > 11) || (yPos > 1)) return;
            if(selected[yPos,xPos])
                selected[yPos, xPos] = false;
            else
                selected[yPos, xPos] = true;
            ((Panel)sender).Invalidate(new Rectangle(xPos * 40,yPos *40,40,40)) ;
        }
    }
