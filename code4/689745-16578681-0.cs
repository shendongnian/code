    protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
    
      // your Code 
      Session["filepathImage"] = filepathImage ; // put the path in session variable 
    
    }
    
    protected void btnDone_Click(object sender, EventArgs e)
    {
        if(Session["filepathImage"]!=null)
        {
             string filepathImage = Session["filepathImage"] as string;
             // your code ...
        }
    }
