    object misValue = System.Reflection.Missing.Value;
    string paramExportFilePath = @"C:\Test2.pdf";
    Excel.XlFixedFormatType paramExportFormat = Excel.XlFixedFormatType.xlTypePDF;
    Excel.XlFixedFormatQuality paramExportQuality = Excel.XlFixedFormatQuality.xlQualityStandard;
    bool paramOpenAfterPublish = false;
    bool paramIncludeDocProps = true;
    bool paramIgnorePrintAreas = true;
    if (xlWorkBook != null)//save as pdf
        xlWorkBook.ExportAsFixedFormat(paramExportFormat, paramExportFilePath, paramExportQuality,     paramIncludeDocProps, paramIgnorePrintAreas, 1, 1, paramOpenAfterPublish, misValue);
