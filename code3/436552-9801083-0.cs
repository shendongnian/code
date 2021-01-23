    Response.Clear(); 							
    Response.ContentType = "application/vnd.ms-excel";
    //Response.ContentEncoding = Encoding.Default; 
    //Response.Charset=""; 
    Response.AddHeader("Content-Disposition: ",
        String.Format(@"attachment; filename={0}",myfileName));
	
    //EnableViewState = false; 
    Response.Write(myFileContentAsString); 
    Response.Flush();
    Response.Close();
