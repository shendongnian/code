    Bitmap bm = new Bitmap(800, 800);
    using (Graphics g = Graphics.FromImage(bm))
    using (SolidBrush blackBrush = new SolidBrush(Color.Black))
    using (SolidBrush whiteBrush = new SolidBrush(Color.White))
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                    g.FillRectangle(blackBrush, i * 100, j * 100, 100, 100);
                else if ((j % 2 == 0 && i % 2 != 0) || (j % 2 != 0 && i % 2 == 0))
                    g.FillRectangle(whiteBrush, i * 100, j * 100, 100, 100);
            }
        }
        BackgroundImage = bm;
    }
