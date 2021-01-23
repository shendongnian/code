    foreach (var slideMasterPart in PresentationPart.SlideMasterParts)
    {
        foreach (var layouts in slideMasterPart.SlideLayoutParts)
        {
        get each of the layouts.SlideLayout.CommonSlideData.ShapeTree.Descendants<NonVisualDrawingProperties>();
                    and put the name attribute to the grid.
        }
    }
