    protected void btnup_Click(object sender, EventArgs e)
    { 
    
    	string fileExt  = string.Empty; 
    	string extension = string.Empty;
    	string id = string.Empty;
    	string fileLocation = string.Empty;
    
        if (ASPxUploadControl1.HasFile)
    	{              
    	     fileExt = Path.GetExtension(ASPxUploadControl1.FileName);
    		 if (fileExt == ".xls" || fileExt == ".xlsx")
    		 {
    		   try
    		   {
          	 	 extension = Path.GetExtension(ASPxUploadControl1.FileName);
    			 id = Guid.NewGuid().ToString();
    			 fileLocation = string.Format("{0}/{1}{2}", Server.MapPath("upload/"), id, extension);
    			 ASPxUploadControl1.SaveAs( fileLocation );
    			 StatusLabel.Text = "Upload status: File uploaded!";
    			 Newfilename = fileLocation;
    			 Defaultfilename = Path.GetFileName(ASPxUploadControl1.FileName);
    			}                  
    			catch (Exception ex)
    			{
       			  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
     		    }
    		 }
    		 else
    		{
       		  StatusLabel.Text = "Please choose excel file";
      	    }
    	}
    }
	
