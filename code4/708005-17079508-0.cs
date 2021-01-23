    FileInfo FI = new FileInfo(Path);
    StringWriter stringWriter = new StringWriter();
    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
    DataGrid DataGrd = new DataGrid();
    DataGrd.DataSource = dt1;
    DataGrd.DataBind();
    DataGrd.RenderControl(htmlWrite);
    string directory = Path.Substring(0, Path.LastIndexOf("\\"));// GetDirectory(Path);
    if (!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);
    }
    System.IO.StreamWriter vw = new System.IO.StreamWriter(Path, true);
    stringWriter.ToString().Normalize();
    vw.Write(stringWriter.ToString());
    vw.Flush();
    vw.Close();
    WriteAttachment(FI.Name, "application/vnd.ms-excel", stringWriter.ToString());
