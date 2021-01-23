    private void test() {
        //Output the file to the desktop
        var testFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
        //Standard PDF creation here, nothing special
        using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
            using (var doc = new Document()) {
                using (var writer = PdfWriter.GetInstance(doc, fs)) {
                    doc.Open();
                    //Create a random number generator to create some random dimensions and colors
                    var r = new Random();
                    //Placeholders for the loop
                    int w, h;
                    Color c;
                    iTextSharp.text.Image img;
                    //Create 5 images
                    for (var i = 0; i < 5; i++) {
                        //Create some random dimensions
                        w = r.Next(25, 500);
                        h = r.Next(25, 500);
                        //Create a random color
                        c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                        //Create a random image
                        img = iTextSharp.text.Image.GetInstance(createSampleImage(w, h, c));
                        //Scale the image
                        img.ScaleToFit(80f, 80f);
                        //Add it to our document
                        doc.Add(img);
                    }
                    doc.Close();
                }
            }
        }
    }
    /// <summary>
    /// Create a single solid color image using the supplied dimensions and color
    /// </summary>
    private static Byte[] createSampleImage(int width, int height, System.Drawing.Color color) {
        using (var bmp = new System.Drawing.Bitmap(width, height)) {
            using (var g = Graphics.FromImage(bmp)) {
                g.Clear(color);
            }
            using (var ms = new MemoryStream()) {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
