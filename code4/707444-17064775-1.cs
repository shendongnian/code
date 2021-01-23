    foreach (NetOffice.WordApi.InlineShape s in docWord.InlineShapes)
    {
        if (s.Type==NetOffice.WordApi.Enums.WdInlineShapeType.wdInlineShapePicture &&   s.AlternativeText.Contains("|"))
        {
            //save the html content to a file
            File.WriteAllText(temporaryFilePath, html);  
            s.Range.InsertFile(temporaryFilePath);             
        }
    }
