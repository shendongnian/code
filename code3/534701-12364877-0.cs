    private void ProccessBitmap(Bitmap img, Bitmap original_cell)
        {
            int cellWidth = img.Width / 24;
            int cellHeight = img.Height / 4;
            IList<KeyValuePair<float, Rectangle>> table = new List<KeyValuePair<float, Rectangle>>();
            Bitmap cell;
            Rectangle rect;
            AForge.Imaging.ExhaustiveTemplateMatching tm = new AForge.Imaging.ExhaustiveTemplateMatching(0);
            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 24; colIndex++)
                {
                    rect = new Rectangle(colIndex * cellWidth, rowIndex * cellHeight, cellWidth, cellHeight);
                    cell = img.Clone(rect, img.PixelFormat);
                    var matchings = tm.ProcessImage(original_cell, cell);
                    table.Add(new KeyValuePair<float, Rectangle>(matchings[0].Similarity, rect));
                    cell.Dispose();
                }
            }
            using (Graphics gr = Graphics.FromImage(img))
            {
                gr.DrawRectangles(new Pen(Color.Red, 3.0f), table.OrderBy(a => a.Key).Take(24).Select(a => a.Value).ToArray());
            }
            pictureBox1.Image = img;
        }
