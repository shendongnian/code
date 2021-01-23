	public void exportarPDF(Bitmap img){		   
		// System.Drawing.Image image = System.Drawing.Image.FromFile("C://snippetsource.jpg"); Aca graba con un archivo fisico
		System.Drawing.Image image = img;  //Here I passed a bitmap
		Document doc = new Document(PageSize.A4);
		PdfWriter.GetInstance(doc, new FileStream("C://image.pdf", FileMode.Create));
		doc.Open();
		iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image,
				System.Drawing.Imaging.ImageFormat.Jpeg);
		doc.Add(pdfImage);
		doc.Close();
	}
