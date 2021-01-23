    using (var bmp = new Bitmap(mat.ColumnCount, mat.RowCount)) {
        using (var g = Graphics.FromImage(bmp)) {
            ....
            g.FillRectangle(Brushes.Red, 0, 0, 20, 20);
            ....
        }
    }
    bmp.Save(...);
