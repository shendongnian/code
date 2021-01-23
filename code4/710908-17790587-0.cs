    // Create document
    FREngine.FRDocument document = engineLoader.Engine.CreateFRDocument();
    document.AddImageFile( imagePath, null, null );
    // . . .
    FREngine.ImageDocument imageDoc = document.Pages[pageNumber].ImageDocument;
    IntPtr hBitmap = ( IntPtr )( imageDoc.ColorImage.GetPicture( null, 0 ) );
    Bitmap bitmap = Bitmap.FromHbitmap( hBitmap );
    // Perform manipulations with Bitmap object
    // . . .
    document.Close();
    document = engineLoader.Engine.CreateFRDocument();
    
    int manipulatedHBitmap = ( int )( bitmap.GetHbitmap() );
    FREngine.ImageDocument imageDocument = engineLoader.Engine.OpenBitmapImage( manipulatedHBitmap, resolution );
    document.AddImage( imageDocument );
    // Perform image processing with the FineReader Engine
    // . . .
