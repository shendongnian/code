            using (var g = Graphics.FromImage(bmpPattern))
            {
                g.Clear(Color.Black);
                g.SmoothingMode = SmoothingMode.HighQuality;
                for (var y = 0; y < bmp.Height; y += 10)
                    for (var x = 0; x < bmp.Width ; x += 6)
                    {
                        g.FillEllipse(Brushes.White, x, y, 4, 4);
                        g.FillEllipse(Brushes.White, x + 3, y + 5, 4, 4);
                    }
            }
