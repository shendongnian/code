        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";//check your valid file type
        Response.AddHeader("Content-Disposition", "attachment;filename=" + targetFileName);
        Response.Charset = "";
        
        using (System.IO.StreamWriter writer = new StreamWriter(Response.OutputStream)
        {
            //writer.Write(contentBytes);
        }
        Response.Flush();
        Response.Close();
        Context.ApplicationInstance.CompleteRequest();
