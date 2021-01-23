        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Load +=new EventHandler(Form1_Load);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Box box = new Box(new Rectangle(0, 0, 100, 100));
                box.Width = 200;
                box.Height = 200;
                this.Controls.Add(box);
            } 
    
        }
    
        public class Box : Control
        {
            public Rectangle rect;
    
            public Box(Rectangle rect)
            {
                this.rect = rect;
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
    
                e.Graphics.FillRectangle(new SolidBrush(Color.Chocolate), rect);
                base.OnPaint(e);
            }
    
    
    
        } 
