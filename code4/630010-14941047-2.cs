            string txtString = Request["txtString"];
            Response.Clear();
            Response.AppendHeader(
            "Content-Disposition", 
            "attachment; 
            filename=myFile.txt"
            );
            Response.ContentType = "application/x-download";
            Response.Write(txtString);
            Response.End();
