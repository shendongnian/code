            Bitmap source = new Bitmap("input.png");
            Rectangle rec = new Rectangle(0, 0, 80, 144);
            
            Bitmap[] parts = new Bitmap[10];
            for (int i = 0; i < 10; i++)
            {
                rec.Y = 144 * i;
                Bitmap b = (Bitmap)cropImage(source, rec);
                b.Save(String.Format("{0}.png", i), ImageFormat.Png);
                parts[i] = b;
            }
            Bitmap output = new Bitmap(source.Width, source.Height);
            Graphics g = Graphics.FromImage(output);
            for(int i=0; i<10; i++)
            {
                Bitmap b = parts[i];
                g.DrawImageUnscaled(b, new Point(0, i * 144));
            }
            output.MakeTransparent(Color.Transparent); // test if the image view don't changes, use this to reduce the overhead, in my test it reduced output size by 10 percent without changing the view
            output.Save("output.png", ImageFormat.Png);
