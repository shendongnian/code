        var toRemove = new int[] { 1,2,.... };
    	slidePart.Slide
		    .Descendants<DocumentFormat.OpenXml.Presentation.Picture>()
     	    .Where((x, i) => toRemove.Contains(i) )
		    .ToList()
		    .ForEach(pic => pic.Remove());
