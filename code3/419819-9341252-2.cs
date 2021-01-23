    public partial class Form1 : Form
    {
       public Form1()
       {
          InitializeComponent();
          ((Bitmap)toolStripButton1.Image).DrawText("B", Font, SystemBrushes.ControlText,
             new RectangleF(new PointF(0, 0), toolStripButton1.Image.Size));
       }
    }
    public static class ImageExtensions
    {
       public static void DrawText(this Bitmap image, string stringToDraw, Font font,
          Brush brush, RectangleF rectangleF)
       {
          using (Graphics g = Graphics.FromImage(image))
          {
             g.DrawString(stringToDraw, font, brush, rectangleF);
          }
       }
    }
