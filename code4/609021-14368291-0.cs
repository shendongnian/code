    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    // ...
    // create application object
    PowerPoint.Application pptApplication = new PowerPoint.Application();
    PowerPoint.Slides slides;
    PowerPoint._Slide slide;
    PowerPoint.TextRange objText;
    // Create the Presentation File
    PowerPoint.Presentation pptPresentation = pptApplication.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoTrue);
    // APPLY THEME - for example Clarity.thmx or 
    // anything within Microsoft Office\Document Themes 14    
    pptPresentation.ApplyTheme(@"C:\Program Files (x86)\Microsoft Office\Document Themes 14\Clarity.thmx");
    PowerPoint.CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutText];
    // Create new Slide
    slides = pptPresentation.Slides;
    slide = slides.AddSlide(1, customLayout);
    // Add title
    objText = slide.Shapes[1].TextFrame.TextRange;
    objText.Text = "FPPT.com";
    objText.Font.Name = "Arial";
    objText.Font.Size = 32;
    objText = slide.Shapes[2].TextFrame.TextRange;
    objText.Text = "Content goes here\nYou can text\nItem 3";
    slide.NotesPage.Shapes[2].TextFrame.TextRange.Text = "This demo is created by FPPT using C# - Download free templates from http://FPPT.com";
    pptPresentation.SaveAs(@"e:\temp\fppt.pptx", PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Microsoft.Office.Core.MsoTriState.msoTrue);
    //pptPresentation.Close();
    //pptApplication.Quit();
