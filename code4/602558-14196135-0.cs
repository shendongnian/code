    FileInfo newExcelFile;
    for (int i = 0; i < int.MaxValue; i++)
    {
        newExcelFile = new FileInfo(string.Format(@"Output{0}.xlsx", i));
        if (!newExcelFile.Exists)
        {
            break;
        }
        newExcelFile = null;
    }
    if (newExcelFile == null)
    {
        // do you want to try 2147483648
        // or show an error message
        // or throw an exception?
    }
    else
    {
        // save your file
    }
