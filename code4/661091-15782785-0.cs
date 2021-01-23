    foreach (PowerPoint.Slide slide in presentation.Slides)
    {
        foreach (PowerPoint.Shape pptshape in slide.Shapes)
        {
            if(<your condition satisfies>)
            {
                slide.Select(); // some position in any slide
                pptshape.Delete();//delete old content that was in that slide
                ppApp.ActiveWindow.View.PasteSpecial(); //paste the Excel content
            }
        }
    }
