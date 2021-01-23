    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    using Core = Microsoft.Office.Core;
    // ...
    // create application object
    PowerPoint.Application pptApplication = new PowerPoint.Application();
    PowerPoint.Slides slides;
    PowerPoint._Slide slide;
    PowerPoint.TextRange objText;
    // Create the Presentation File
    PowerPoint.Presentation pptPresentation = pptApplication.Presentations.Add(Core.MsoTriState.msoTrue);
    // APPLY THEME - for example Clarity.thmx or 
    // anything within Microsoft Office\Document Themes 14    
    pptPresentation.ApplyTheme(@"C:\Program Files (x86)\Microsoft Office\Document Themes 14\Clarity.thmx");
    PowerPoint.CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutText];
    // Create new Slide
    slides = pptPresentation.Slides;
    slide = slides.AddSlide(1, customLayout);
    // Add title, modify content and so on ...
    objText = slide.Shapes[1].TextFrame.TextRange;
    objText.Text = "hello world";
    objText.Font.Name = "Verdana";
    pptPresentation.SaveAs(@"c:\yourPPT.pptx", PowerPoint.PpSaveAsFileType.ppSaveAsDefault, Core.MsoTriState.msoTrue);
    
    pptPresentation.Close();
    pptApplication.Quit();
    GC.Collect();
