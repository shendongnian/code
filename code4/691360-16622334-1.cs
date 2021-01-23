        Color[,] colorsTable;
        Bitmap b;
        Graphics g;
        int size = 80;  // size of table 
        int pixelWidth = 5; // size of each pixel
        Random r = new Random();
        int rand;
        // CMDDraw is my Form button which draws the image 
 
        private void CMDDraw_Click(object sender, EventArgs e)
        {
            colorsTable = new Color[size, size];
            pictureBox1.Size = new Size(size * pixelWidth, size * pixelWidth);
            b = new Bitmap(size * pixelWidth, size * pixelWidth);
            g = Graphics.FromImage(b);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    rand = r.Next(0, 4);
                    switch (rand)
                    {
                        case 0: colorsTable[x, y] = Color.White; break;
                        case 1: colorsTable[x, y] = Color.Red; break;
                        case 2: colorsTable[x, y] = Color.Blue; break;
                        case 3: colorsTable[x, y] = Color.Lime; break;
                        default: break;
                    }
                    g.FillRectangle(new SolidBrush(colorsTable[x, y]), x * pixelWidth, y * pixelWidth, pixelWidth, pixelWidth);
                }
            }
            pictureBox1.Image = b;
        } 
