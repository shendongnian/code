    private void ThisAddIn_Startup(object sender, System.EventArgs e) {
        this.Application.PresentationNewSlide += Application_PresentationNewSlide;
    }
    
    void Application_PresentationNewSlide(PowerPoint.Slide Sld) {
        PowerPoint.Shape textBox = Sld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 500, 50);
        textBox.Name = "shape1";
        textBox.TextFrame.TextRange.InsertAfter("This text was added by using code.");
                
        textBox = Sld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 0, 100, 500, 50);
        textBox.TextFrame.TextRange.InsertAfter("This text was also added by using code.");
        textBox.Name = "shape2";
    
        PowerPoint._Application myPPT = Globals.ThisAddIn.Application;
        PowerPoint.Slide curSlide = myPPT.ActiveWindow.View.Slide;
        string[] myRangeArray = new string[2];
        myRangeArray[0] = "shape1";
        myRangeArray[1] = "shape2";
        curSlide.Shapes.Range(myRangeArray).Group();
    }
