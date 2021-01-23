    FiltersSequence preOcr = new FiltersSequence(
        Grayscale.CommonAlgorithms.BT709, 
        new BradleyLocalThresholding());
    Bitmap grayscale = preOcr.Apply(original);
    var labels = new ConnectedComponentsLabeling();
    labels.Apply(new Invert().Apply(grayscale));
    //Console.WriteLine(labels.ObjectCount);    // Here you go
    foreach (var candidate in labels.BlobCounter.GetObjectsInformation())
    {
        using (Bitmap symbol = new Bitmap(candidate.Rectangle.Width, 
                                          candidate.Rectangle.Height))
        using (Graphics g2 = Graphics.FromImage(symbol))
        {
            g2.DrawImage(grayscale, 0, 0, candidate.Rectangle, GraphicsUnit.Pixel);
            symbol.Save(String.Format(@"temp\{0}-{1}.jpg",i,++n), ImageFormat.Jpeg);
            // do stuff
        }
    }
