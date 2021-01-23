    Doc theSrc = new Doc();
    theSrc.Read("C://development//pdfSplitter//Bxdfbc91ca-fc05-4315-8c40-798a77431ee0xP.pdf");
    int srcPagesID = theSrc.GetInfoInt(theSrc.Root, "Pages");
    int srcDocRot = theSrc.GetInfoInt(srcPagesID, "/Rotate");
    for (int i = 1; i <= theSrc.PageCount; i++)
    {   
        Doc singlePagePdf = new Doc();
        singlePagePdf.Rect.String = singlePagePdf.MediaBox.String = theSrc.MediaBox.String;
        singlePagePdf.AddPage();
        singlePagePdf.AddImageDoc(theSrc, i, null);
        singlePagePdf.FrameRect();
        int srcPageRot = theSrc.GetInfoInt(theSrc.Page, "/Rotate");
        if (srcDocRot != 0)
        {
	        singlePagePdf.SetInfo(singlePagePdf.Page, "/Rotate", srcDocRot);
        }
        if (srcPageRot != 0)
        {
            singlePagePdf.SetInfo(singlePagePdf.Page, "/Rotate", srcPageRot);
        }
        singlePagePdf.Save("C://development//pdfSplitter//singlePDF//singlePage"+i+".pdf");
        singlePagePdf.Clear();
    }
    theSrc.Clear();
