    string _paperSource = "TRAY 2"; // Printer Tray
    string _paperName = "8x17"; // Printer paper name
    //Tested code comment. The commented code was the one I tested, but when 
    //I was writing the post I realized that could be done with less code.
	
    //PaperSize pSize = new PaperSize()  //Tested code :)
    //PaperSource pSource = new PaperSource(); //Tested code :)
    /// Find selected paperSource and paperName.
    foreach (PaperSource _pSource in printDoc.PrinterSettings.PaperSources)
    {
        if (_pSource.SourceName.ToUpper() == _paperSource.ToUpper())
        {
            printDoc.DefaultPageSettings.PaperSource = _pSource;
            //pSource = _pSource; //Tested code :)
            break;
        }
    }
    foreach (PaperSize _pSize in printDoc.PrinterSettings.PaperSizes)
    {
        if (_pSize.PaperName.ToUpper() == _paperName.ToUpper())
        {
            printDoc.DefaultPageSettings.PaperSize = _pSize;
            //pSize = _pSize; //Tested code :)
            break;
        }
    }
	 
    //printDoc.DefaultPageSettings.PaperSize = pSize; //Tested code :)
    //printDoc.DefaultPageSettings.PaperSource = pSource;	 //Tested code :)
