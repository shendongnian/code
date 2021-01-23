            Response.Clear();
            Response.ContentType = "Application/msword";
            Response.AddHeader("Content-Disposition", "attachment; filename=myfile.docx");
            Response.BinaryWrite(myMemoryStream.ToArray());
            // myMemoryStream.WriteTo(Response.OutputStream); //works too
            Response.Flush();
            Response.Close();
            Response.End();
