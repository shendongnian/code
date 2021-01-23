       Slide activeSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
       Microsoft.Office.Interop.PowerPoint.Shape ppPicture =
       activeSlide.Shapes.AddPicture(imageurl ,
       MsoTriState.msoTrue, MsoTriState.msoTrue, 0, 0);
       ppPicture.LinkFormat.SourceFullName = imageurl 
     }
  
