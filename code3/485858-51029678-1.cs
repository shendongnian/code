        private void button1_Click(Object sender, EventArgs e)
        {
            Pen selPen = new Pen(Color.Red, 2);  //  The Op uses random color which is not good idea for testing so we'll choose a solid color not on the existing bitmap and we'll confine our Pen's line size to 2 until we know what we're doing.
            //  Unfortionately the picture box "image" once loaded is not directly usable afterwords.
            //  We need tp recreate the pictureBox1 image to a usable form, being the "newBmp", and for efficiency the bitmap type is chosen
            Bitmap newBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppArgb); // Tip: Using System.Drawing.Imaging for pixel format which uses same pixel format as screen for speed
            // We create the graphics from our new and empty bitmap container
            Graphics g = Graphics.FromImage(newBmp);
            // Next we draw the pictureBox1 data array to our equivelent sized bitmap container
            g.DrawImage(pictureBox1.Image, 0, 0);
            g.DrawLine(selPen, 3, 3, 3, 133);  // Format: (pen, x1, y1, x2, y2)
            pictureBox1.Image = newBmp;
            //  Don't forget to dispose of no longer needed resources
            g.Dispose();
            selPen.Dispose();
            newBmp.Dispose(); // or save newBmp to file before dispose ie. newBmp.Save("yourfilepath", ImageFormat.Jpeg) or in whatever image type you disire;
        }
