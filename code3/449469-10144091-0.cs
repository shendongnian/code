    private void export_graf_Click(object sender, RoutedEventArgs e)
    {
        if (mcChart.Series[0] == null)
        {
            MessageBox.Show("there is nothing to export");
        }
        else
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(mcChart);
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, 96, 96, PixelFormats.Pbgra32);
            DrawingVisual isolatedVisual = new DrawingVisual();
            using (DrawingContext drawing = isolatedVisual.RenderOpen())
            {
                drawing.DrawRectangle(Brushes.White, null, new Rect(new Point(), bounds.Size)); // Optional Background
                drawing.DrawRectangle(new VisualBrush(mcChart), null, new Rect(new Point(), bounds.Size));
            }
            renderBitmap.Render(isolatedVisual);
            Microsoft.Win32.SaveFileDialog uloz_obr = new Microsoft.Win32.SaveFileDialog();
            uloz_obr.FileName = "Graf";
            uloz_obr.DefaultExt = "png";
            Nullable<bool> result = uloz_obr.ShowDialog();
            if (result == true)
            {
                string obr_cesta = uloz_obr.FileName;
                using (FileStream outStream = new FileStream(obr_cesta, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    encoder.Save(outStream);
                }
            }
        }
    }
