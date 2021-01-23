    public ActionResult FillFS(AFViewModel ViewModel) 
    { 
                try
                {		
    			//Execute the SP
    			var TextBoxList = GetListOfTextBox("somevar","somevar2");
    			
    			//Code to populate
    			//ViewModel.TextBox1 && ViewModel.TextBox2		
    					
                }
                catch (Exception ex)
                {
    
                    Response.Write(ex.InnerException.Message);
                }
    
    		return PartialView("_AFTab"); 
    }
