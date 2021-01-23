    public class MyControl : Control 
    {
        public override void OnPaint(PaintEventArgs e)
        {
           base.OnPaint(e); 
           DrawingSquares(e.Graphics, valueX, valueY);
        }
    
        public void DrawingSquares(Graphics graphicsObj, int x, int y)
        {      
           Pen myPen = new Pen(System.Drawing.Color.Black, 5);
           Rectangle myRectangle = new Rectangle(x, y, 100, 100);
           graphicsObj.DrawRectangle(myPen, myRectangle);
        }
    
    }
