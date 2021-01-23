    public abstract class MyShape
    {
       public abstract void Draw(PaintEventArgs args);
    }
    public class MyRectangle : MyShape
    {
        public int Height { get; set; }
        public int Width { get;set; }
        public int X { get; set; }
        public int Y { get; set; }
    
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(
                new SolidBrush(Color.Black),
                new Rectangle(X, Y, Width, Height));
        }
    }
    public class MyCircle : MyShape
    {
        public int Radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    
        public override void Draw(Graphics graphics)
        {
            /* drawing code here */
        }        
    }
    
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        List<MyShape> toDraw = new List<MyShape> 
        {
            new MyRectangle
            {
                Height = 10,
                Width: 20,
                X = 0,
                Y = 0
            },
            new MyCircle
            {
               Radius = 5,
               X = 5,
               Y = 5
            }
        };
    
        toDraw.ForEach(s => s.Draw(e.Graphics));
    }
