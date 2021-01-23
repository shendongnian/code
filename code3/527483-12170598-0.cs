    bool focusResults = false;
        protected void cfmTest_Sumit(object sender, EventArgs e)
        {
          txtResult.Text = "User Confirmed";
         focusResults = true;
        }
    
        protected override void OnPreRender(EventArgs e)
        {
           base.OnPreRender(e);
    
            if(focusResults)
               txtResult.Focus();
        }
