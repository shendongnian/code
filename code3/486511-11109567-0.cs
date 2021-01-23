        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              /// Access Master Page control
              LinkButton lnkButton = (LinkButton)this.Master.FindControl("lnkButtonName");
              /// set postback url or whatever
              lnkButton.PostBackUrl = "";
            }
            catch(Execption e)
            {}
        }  
