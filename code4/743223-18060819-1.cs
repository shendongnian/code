    void ExportToExcel(Event evt)
    {
        var fileInfo = new FileInfo(Path.GetTempPath() + "\\" +  
                                    DateTime.Now.Ticks + ".xlsx");
     
        using (var xls = new ExcelPackage(fileInfo))
        {
            var sheet = xls.Workbook.Worksheets.Add(evt.Title);
     
            sheet.Cell(1, 1).Value = "First name";
            sheet.Cell(1, 2).Value = "Last name";
            sheet.Cell(1, 3).Value = "E-mail";
            sheet.Cell(1, 4).Value = "Phone";
            sheet.Cell(1, 5).Value = "Registered";
            sheet.Cell(1, 6).Value = "Live Meeting";
     
            var i = 1;
            foreach(var attendee in evt.Attendees)
            {
                i++;
     
                var profile = attendee.Profile;
                sheet.Cell(i, 1).Value = profile.FirstName;
                sheet.Cell(i, 2).Value = profile.LastName;
                sheet.Cell(i, 3).Value = profile.Email;
                sheet.Cell(i, 4).Value = profile.Phone;
                sheet.Cell(i, 5).Value = att.Created.ToString();
                sheet.Cell(i, 6).Value = att.LiveMeeting.ToString();
            }
     
            xls.Save(); 
        }
     
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats";
        Response.AddHeader("Content-Disposition", 
                           "attachment; filename=" + fileInfo.Name);
        Response.WriteFile(fileInfo.FullName);
        Response.Flush();
     
        if (fileInfo.Exists)
            fileInfo.Delete(); 
    }
