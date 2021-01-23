     MODI.Document modiDoc = null;
        MODI.MiDocSearch modiSearch = null;
        MODI.IMiSelectableItem modiTextSel = null;
        MODI.MiSelectRects modiSelectRects = null;
        MODI.MiSelectRect modiSelectRect = null;
        MODI.MiRects modiRects = null;
        int intSelInfoPN;
        int intSelInfoTop;
        int intSelInfoBottom;
        int intSelInfoLeft;
        int intSelInfoRight;
        // Load an existing image file.
        modiDoc = new MODI.Document();
        modiDoc.Create(@"C:\Users\h117953\Desktop\OCR\1.jpg");
        // Perform OCR.
        //modiDoc.Images[0].OCR();
        //MODI.Image image = (MODI.Image)modiDoc.Images[0];
        modiDoc.OCR(MiLANGUAGES.miLANG_ENGLISH);
        MODI.Image modiImage = (modiDoc.Images[0] as MODI.Image);
        //string ocrtext = @"C:\Users\h117953\Desktop\OCR\Sample.txt";
        //File.WriteAllText(ocrtext, modiImage.Layout.Text);
        // Search for the selected word.
        //int wordindex
        modiSearch = new MODI.MiDocSearch();
        //date to search 
        modiSearch.Initialize(modiDoc, "Deer", 0, 2, false, false);
        modiSearch.Search(null, ref modiTextSel);
        if (modiTextSel == null)
        {
            Response.Write("\nText not found \n");
           
        }
        else
        {
            Response.Write("\nText is found \n");
            try
            {
                modiSelectRects = modiTextSel.GetSelectRects();
            }
            catch (Exception)
            {
                Response.Write("Me thinks that the OCR didn't work right!");
            }
            int centerwidth = 0;
            int centerheight = 0;
            foreach (MODI.MiSelectRect mr in modiSelectRects)
            {  
                //intSelInfoPN = mr.PageNumber.ToString();
                intSelInfoTop = mr.Top;
                intSelInfoBottom = mr.Bottom;
                intSelInfoLeft = mr.Left;
                intSelInfoRight = mr.Right;
                // MessageBox.Show("Coordinates: " + intSelInfoLeft + ", " + intSelInfoTop, "Coordinates", MessageBoxButtons.OK);
                //  MessageBox.Show("Coordinates: " + intSelInfoRight + ", " + intSelInfoBottom, "Coordinates", MessageBoxButtons.OK);
                centerwidth = (intSelInfoRight - intSelInfoLeft) / 2;
                centerwidth = intSelInfoLeft + centerwidth;
                centerwidth = (intSelInfoBottom - intSelInfoTop) / 2;
                centerheight = centerheight + intSelInfoTop;
                //MessageBox.Show("Coordinates: " + centerwidth + ", " + centerheight, "Coordinates", MessageBoxButtons.OK);
                Response.Write("the Widht and Height co-ordinates are (Width,Height)= ({0},{1})" + centerwidth + ","+ centerheight);
            }
