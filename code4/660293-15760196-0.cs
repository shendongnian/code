     public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        Rectangle rect = new Rectangle(); 
           Color _rastercolor = Color.Black;
           private Pen _pen=new Pen(Color.Red,2);
            private void tekenGrid(Color rastercolor,  Graphics gfx)
            {
             
                Pen pen = new Pen(rastercolor);
                for (int i = 0; i <= 2000; i = i + 20)
                {
                    gfx.DrawLine(pen, 0, i, 2000, i);
                }
                for (int x = 0; x < 2000; x = x + 20)
                {
                    gfx.DrawLine(pen, x, 0, x, 2000);
                }
            }
            protected override void OnMouseDown(MouseEventArgs e)
            {
                rect = new Rectangle(e.X, e.Y, 0, 0);
                if (e.Button == MouseButtons.Middle)
                {
                    ColorDialog coldial = new ColorDialog();
                    coldial.ShowDialog();
                    Color rastercolor = coldial.Color;
                    tekenGrid(rastercolor,this.CreateGraphics());
                }
                else
                base.OnMouseDown(e);
            }
            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rect = new Rectangle(rect.Left, rect.Top, e.X - rect.Left, e.Y - rect.Top);
                    this.Refresh();
                }
               
                base.OnMouseMove(e);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                tekenGrid(_rastercolor,e.Graphics);
                    e.Graphics.DrawRectangle(_pen, rect);
            }
            private void Frm1_MouseUp(object sender, MouseEventArgs e)
            {
                _pen = new Pen(Color.Red, 2);
                this.Refresh();
            }
            private void Frm1_Load(object sender, EventArgs e)
            {
            }
            private void Frm1_MouseDown(object sender, MouseEventArgs e)
            {
               _pen = new Pen(Color.Blue, 2);
               
            }
       
    }
