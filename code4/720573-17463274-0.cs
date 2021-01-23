        var imageFile = (from i in db.Attachments
                 where i.IncidentActionID == _tempAction.IncidentActionsID
                 select i).FirstOrDefault();
    Response.Clear();
    Response.ContentType = "application/octet-stream";
    Response.AddHeader("Content-Disposition", "attachment;filename=" + imageFile.FileName + "");
    Response.BinaryWrite(imageFile.Attachments);
    Response.End();
            
