    //We get the file extension
    fileExt = Path.GetExtension(fileName);
    //Declare the sheet interface
    ISheet sheet;
    //Get the Excel file according to the extension
    if (fileExt.ToLower() == ".xls")
    {
        //Use the NPOI Excel xls object
        HSSFWorkbook hssfwb;
        using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            hssfwb = new HSSFWorkbook(file);
        }
        //Assign the sheet
        sheet = hssfwb.GetSheet(sheetName);
    }
    else //.xlsx extension
    {
        //Use the NPOI Excel xlsx object
        XSSFWorkbook hssfwb;
        using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            hssfwb = new XSSFWorkbook(file);
        }
        //Assign the sheet
        sheet = hssfwb.GetSheet(sheetName);
    }
