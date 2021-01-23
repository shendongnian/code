     *To directly download file to your computer on button click just write this code on click event of button*
    string filename = "~/File/yourFolder/"+ FileName;
        string path = MapPath(filename);
        byte[] bts = System.IO.File.ReadAllBytes(path);
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("Content-Type", "Application/octet-stream");
        Response.AddHeader("Content-Length", bts.Length.ToString());
        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        Response.BinaryWrite(bts);
        Response.Flush();
        Response.End();
