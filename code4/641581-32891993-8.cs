    //open a pdf document
    document.Open(testfile, "");
    IacPage page1 = document.GetPage(1);
    Amyuni.PDFCreator.IacAttribute attribute = page1.AttributeByName("Objects");
    // listObj is an array list of graphic objects
    System.Collections.ArrayList listobj = (System.Collections.ArrayList) attribute.Value.Cast<IacObject>();;
    // listObjToKeep is an array list of graphic objects inside a rectangle
    var listObjToKeep = document.GetObjectsInRectangle(0f, 0f, 600f, 115f, 	IacGetRectObjectsConstants.acGetRectObjectsIntersecting).Cast<IacObject>();
    foreach (IacObject pdfObj in listObj.Except(listObjToKeep))
    {
       // if pdfObj is not in visible inside the rectangle then call pdfObj.Delete();
       pdfObj.Delete(false);
    }
