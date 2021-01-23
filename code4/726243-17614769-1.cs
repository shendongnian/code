    Try this  
        if(IsPostBack)
         {            			
           if(btnNew.Style.Value == "Display:none;")
          {
            	 GenerateBlankTableHtml("");
          }            			
        }
    
       protected void btnNew_Click(object sender, EventArgs e)
        {
          GenerateBlankTableHtml("");
        }
