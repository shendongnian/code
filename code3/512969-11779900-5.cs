        protected void Page_Load(object sender, EventArgs e)
        {
            string target = Request["__EVENTTARGET"];
            string argument = Request["__EVENTARGUMENT"];
            
            if (!string.IsNullOrEmpty(target) && target.Equals("UserConfirmedFormSubmission"))
            {
                 if ( !string.IsNullOrEmpty(argument) && argument.equals("CloseWindow"))
                 {
                    this.HandleUserRequestedCloseWinow();
                 }
            }
        }
