    public void Save(ReportViewer viewer, string savePath)
    {
    	byte[] Bytes = viewer.LocalReport.Render("PDF", "", null, null, null, null, null);
    
    	using (FileStream Stream = new FileStream(savePath, FileMode.Create)) {
    		Stream.Write(Bytes, 0, Bytes.Length);
    	}
    }
