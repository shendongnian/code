            Word.Application wrdApplication = new Word.Application();
            Word.Document wrdDocument;
            wrdDocument = wrdApplication.Documents.Add();
            wrdDocument.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            wrdDocument.PageSetup.TopMargin = InchesToPoints(0.5f); //half an inch in points
            wrdDocument.PageSetup.BottomMargin = InchesToPoints(0.5f);
            wrdDocument.PageSetup.LeftMargin = InchesToPoints(0.5f);
            wrdDocument.PageSetup.RightMargin = InchesToPoints(0.5f);
            wrdApplication.Visible = true;
