    using (FileStream aFile = new FileStream(@"C:\Temp\asdf.xlsx", FileMode.Create))
    {
        aFile.Seek(0, SeekOrigin.Begin);
        package.SaveAs(aFile);
        aFile.Close();
    }
    
    // See here - I can still work with the spread sheet.
    var worksheet = package.Workbook.Worksheets.Single(); 
