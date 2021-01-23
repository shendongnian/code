    using( Image img = Image.FromFile(@"c:\temp\testfile1.tif") ) {
	printDocument.DocumentName = controlNumber;
	printDocument.DefaultPageSettings.Margins = new Margins( 15, 0, 0, 0 );
	printDocument.OriginAtMargins = true;
	printDocument.PrinterSettings.PrinterName = request_printer;
	printDocument.PrinterSettings.Duplex = Duplex.Default;
	FrameDimension frames = new FrameDimension( img.FrameDimensionsList[ 0 ] );
	int pages = img.GetFrameCount( frames );
	if( printDocument.PrinterSettings.IsValid ) {
		try {
			printDocument.PrinterSettings.Duplex = Duplex.Default;
			int page = 0;
			printDocument.PrintPage += ( sender, e ) => {
						img.SelectActiveFrame( frames, page );
						Bitmap bmp = new Bitmap( img );
						pictureBox.Image = bmp;
						pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
						printDocument.DefaultPageSettings.Landscape = false;
						if( bmp.Width > bmp.Height ) {
							 printDocument.DefaultPageSettings.Landscape = true;
						}
						if( printDocument.PrinterSettings.IsValid ) {
							 if( e.PageSettings.PrinterSettings.CanDuplex ) {
									e.PageSettings.PrinterSettings.Duplex = Duplex.Default;
							 }
							 e.Graphics.DrawImage( img, 0, 0 );
							 e.HasMorePages = page < 1;
						}
				 page++;
			};
			printDocument.Print();
			} catch (Exception ex) { }		
	}
