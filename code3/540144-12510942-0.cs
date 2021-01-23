    Image inputImg = Image.FromFile("input.tif");
    var outputImg = new Bitmap(inputImg.Width, inputImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    using (var gr = Graphics.FromImage(outputImg))
        gr.DrawImage(inputImg, new Rectangle(0, 0, inputImg.Width, inputImg.Height));
    outputImg.Save("output.tif", ImageFormat.Tiff);
