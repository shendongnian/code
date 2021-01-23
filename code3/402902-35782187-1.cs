            Word.Application wrdApplication = new Word.Application();
            Word.Document wrdDocument;
            wrdApplication.Visible = true;
            wrdDocument = wrdApplication.Documents.Add();
            wrdDocument.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            wrdDocument.PageSetup.TopMargin = wrdApplication.InchesToPoints(0.5f);
            wrdDocument.PageSetup.BottomMargin = wrdApplication.InchesToPoints(0.5f);
            wrdDocument.PageSetup.LeftMargin = wrdApplication.InchesToPoints(0.5f);
            wrdDocument.PageSetup.RightMargin = wrdApplication.InchesToPoints(0.5f);
