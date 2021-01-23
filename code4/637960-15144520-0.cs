        string getExt = Path.GetExtension(DocumentUNCPath.Text);
        var convertFileId = Guid.NewGuid();
        var convertFilePath = @"c:\temp\" + convertFileId + ".pdf";
        getExt = getExt.ToLower();
        if (WorkExtensions.Contains(getExt))
        {
            WordToPdf(convertFilePath)
        }
        else if (ExcelExtensions.Contains(getExt))
        {
            ExcelToPdf(convertFilePath);
        }
        else if (ImageExtensions.Contains(getExt))
        {
            ImgToPdf(convertFilePath);
        }
