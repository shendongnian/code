            Bitmap bmp = new Bitmap(pbImage.Width, pbImage.Height); // not sure what widht/height you really need
            using (Graphics G = Graphics.FromImage(bmp))
            {
                using (Pen SquarePen = new Pen(Color.Red, 5))
                {
                    G.Clear(Color.Aqua);
                    G.DrawLine(SquarePen, 410, 50, 410, 400);
                    G.DrawEllipse(SquarePen, 50 + x, 50, 100 + x, 50);
                }
            }
            pbImage.Image = bmp;
