    string CurrentDate;
    DateTime saveNow = DateTime.Now;
    CurrentDate = saveNow.Date.ToShortDateString();
    string reportContent = prepareHTM();
    
    string pathFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\As_Build_Report_ "+ CurrentDate + ".html";
    
    using (StreamWriter outfile = new StreamWriter(pathFile, true))
    {
        outfile.WriteLine(reportContent);
    }
    System.IO.FileInfo file = new System.IO.FileInfo(pathFile); 
    Response.Clear(); 
    Response.Charset="UTF-8"; 
    Response.ContentEncoding=System.Text.Encoding.UTF8; 
    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); 
    Response.AddHeader("Content-Length", file.Length.ToString());    
    Response.ContentType = "application/ms-excel";  
    Response.WriteFile(file.FullName); 
    Response.End(); 
