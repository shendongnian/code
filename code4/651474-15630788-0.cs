    //Instantiate Pdf instance by calling its empty constructor
    Aspose.Pdf.Generator.Pdf pdf1 = new Aspose.Pdf.Generator.Pdf();
    //Assign a security instance to Pdf object            
    pdf1.Security = new Aspose.Pdf.Generator.Security();
    //Restrict annotation modification
    pdf1.Security.IsAnnotationsModifyingAllowed = false;
    //Restrict contents modification
    pdf1.Security.IsContentsModifyingAllowed = false;
    //Restrict copying the data
    pdf1.Security.IsCopyingAllowed = false;
    //Allow to print the document
    pdf1.Security.IsPrintingAllowed = true;
    //Restrict form filling
    pdf1.Security.IsFormFillingAllowed = false;
    //Add a section in the Pdf
    Aspose.Pdf.Generator.Section sec1 = pdf1.Sections.Add();
    //Create a text paragraph and set top margin
    Aspose.Pdf.Generator.Text text1 = new Aspose.Pdf.Generator.Text(sec1,"this is text content");
    text1.Margin.Top = 30;
    //Add image
    Aspose.Pdf.Generator.Image img = new Aspose.Pdf.Generator.Image();
    img.ImageInfo.File = "asposelogo.png";
    img.ImageInfo.ImageFileType = Aspose.Pdf.Generator.ImageFileType.Png;
    //Add the text paragraph and image to the section
    sec1.Paragraphs.Add(text1);
    sec1.Paragraphs.Add(img);
    //Save the Pdf                            
    pdf1.Save("test.pdf");
                
        
