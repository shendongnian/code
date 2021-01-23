        public int Index
        {
           get
           {
              if(ViewState["Index"]==null)
              {
                 ViewState["Index"]=0;
              }
              else
              {
                 ViewState["Index"]=int.Parse(ViewState["Index"].ToString())+1;
              }
        
              return int.Parse(ViewState["Index"].ToString());    
           }
       }
                
        protected void Button1_Click(object sender, EventArgs e)
        {
            HtmlGenericControl newControl = new HtmlGenericControl("div");
            newControl.ID = "NEWControl"+Index;
            newControl.InnerHtml = "This is a dynamically created HTML server control.";
            
            PlaceHolder1.Controls.Add(newControl);
        }
