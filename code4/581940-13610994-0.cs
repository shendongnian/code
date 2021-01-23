    var toRemove = new[] { 1, 2, ... };
    var itemsToBeRemoved = slidePart.Slide
        .Descendants<DocumentFormat.OpenXml.Presentation.Picture>()
        .Where((pic, index) => toRemove.Contains(index))
        .ToList();
