    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    ...
    try
    {
        int numberOfSlides = Globals.ThisAddIn
            .Application.ActivePresentation.Slides.Count;
        if (numberOfSlides > 0)
        {
            // get first slide
            PowerPoint.Slide firstSlide = Globals.ThisAddIn
                .Application.ActivePresentation.Slides[0];
            // get first shape (object) in the slide
            int shapeCount = firstSlide.Shapes.Count;
            if (shapeCount > 0)
            {
                PowerPoint.Shape firstShape = firstSlide.Shapes[0];
            }
            // add a label
            PowerPoint.Shape label = firstSlide.Shapes.AddLabel(
                    Orientation: Microsoft.Office.Core
                       .MsoTextOrientation.msoTextOrientationHorizontal,
                    Left: 100,
                    Top: 100,
                    Width: 200,
                    Height: 100);
            // write hello world with a slidenumber
            label.TextFrame.TextRange.Text = "Hello World! Page: ";
            label.TextFrame.TextRange.InsertSlideNumber();
        }
    }
    catch (Exception ex)
    {
        System.Windows.Forms.MessageBox.Show("Error: " + ex);
    }
