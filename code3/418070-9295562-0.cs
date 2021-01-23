    using (Bitmap b = new Bitmap(this.Width, this.Height))
    {
        using (Graphics g = Graphics.FromImage(b))
        {
            g.CopyFromScreen(this.Location, new Point(0, 0), this.Size);
        }
        Document doc = new Document();
        iTextSharp.text.Image i = iTextSharp.text.Image.GetInstance(b, System.Drawing.Imaging.ImageFormat.Bmp);
        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Temp\output.pdf", FileMode.Create));
        doc.SetPageSize(new iTextSharp.text.Rectangle(this.Size.Width + doc.LeftMargin + doc.RightMargin, this.Size.Height + doc.TopMargin + doc.BottomMargin));
        doc.Open();
        doc.Add(i);
        doc.Close();
    }
