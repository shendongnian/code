    public class Form1 : Form
    {
        public Form1()
        {
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        
        //....
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GetPixel_Example(e);
        }
        private void GetPixel_Example(PaintEventArgs e)
        {
            // Create a Bitmap object from an image file.
            Bitmap myBitmap = new Bitmap(@"C:\Users\tanyalebershtein\Desktop\Sample Pictures\Tulips.jpg");
            // Get the color of a pixel within myBitmap.
            Color pixelColor = myBitmap.GetPixel(50, 50);
            // Fill a rectangle with pixelColor.
            SolidBrush pixelBrush = new SolidBrush(pixelColor);
            e.Graphics.FillRectangle(pixelBrush, 0, 0, 100, 100);
        }
    }
