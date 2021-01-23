    //open a pdf document
    document.Open(testfile, "");
    IacPage page1 = document.GetPage(1);
    Amyuni.PDFCreator.IacAttribute attribute = page1.AttributeByName("Objects");
    // listobj is an array list of graphic objects
    System.Collections.ArrayList listobj = (System.Collections.ArrayList) attribute.Value;
    foreach (IacObject pdfObj in listobj )
    {
       // if pdfObj is not in the collection of interest (GetObjectsInRectangle)
       // then call pdfObj.Delete();
    }
