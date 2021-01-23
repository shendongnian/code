        for (int y = img.Height - 1; y >= 0; --y)
        {
            Color rgb = new Color();
            for (int x = 0; x < img.Width; ++x)
            {
                rgb = img.GetPixel(x, y);
                if (rgb.ToArgb().Equals(Color.White.ToArgb()))
                {
                   textBox1.AppendText(" ");
                }
                else
                {
                    textBox1.AppendText("x");
                }
            }
            textBox1.AppendText(Environment.NewLine);
        }
