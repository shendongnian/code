            // make sure you actually drew something
            if (MyLines.Length > 0)
            {
                // instantiate the stuff you need
                Image img = new Bitmap(panel1.Width, panel1.Height);
                Graphics g = Graphics.FromImage(img);
                Pen pen = new Pen(Color.Black, 2);
                // draw every line (from every even index to the one after it)
                for (int i = 0; i < MyLines.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        g.DrawLine(pen, MyLines[i], MyLines[i + 1]);
                    }
                }
                img.Save("C:\\panel.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
