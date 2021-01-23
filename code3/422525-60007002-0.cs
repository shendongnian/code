	static public void MakePdfFrom2Pictures (String pic1InPath, String pic2InPath, String pdfOutPath)
	{
		using (FileStream pic1In = new FileStream (pic1InPath, FileMode.Open))
		using (FileStream pic2In = new FileStream (pic2InPath, FileMode.Open))
		using (FileStream pdfOut = new FileStream (pdfOutPath, FileMode.Create))
		{
			//Load first picture
			Image image1 = Image.GetInstance (pic1In);
			//I set the position in the image, not during the AddImage call
			image1.SetAbsolutePosition (0, 0);
			//Load second picture
			Image image2 = Image.GetInstance (pic2In);
			// ...
			image2.SetAbsolutePosition (0, 0);
			//Create a document whose first page has image1's size.
			//Image IS a Rectangle, no need for new Rectangle (Image.Width, Image.Height).
			Document document = new Document (image1);
			//Assign writer
			PdfWriter writer = PdfWriter.GetInstance (document, pdfOut);
			//Allow writing
			document.Open ();
			//Get writing head
			PdfContentByte pdfcb = writer.DirectContent;
			//Put the first image on the first page
			pdfcb.AddImage (image1);
			//The new page will have image2's size
			document.SetPageSize (image2);
			//Add the new second page, and start writing in it
			document.NewPage ();
			//Put the second image on the second page
			pdfcb.AddImage (image2);
			//Finish the writing
			document.Close ();
		}
	}
