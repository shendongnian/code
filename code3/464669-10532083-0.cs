     //  It will be on your submit button click 
        protected void getPinCode()
        {
            foreach (GridViewRow grdRows in gvSurvey.Rows)
            {
                RadioButton rbt1 = (RadioButton)grdRows.FindControl("rdbtn1");
                RadioButton rbt2 = (RadioButton)grdRows.FindControl("rdbtn2");
                RadioButton rbt3 = (RadioButton)grdRows.FindControl("rdbtn3");
                RadioButton rbt4 = (RadioButton)grdRows.FindControl("rdbtn4");
                string Value = RadioValue(rbt1);
               //Similarly you can do for all radio button 
                if(!string.IsNullOrEmpty(Value))
                {
                    lblMsg.Text = nominationsBiz.SaveSuggestion(ticketNo.ToString(), qtn_no, sqtn_no, Value);
                }
                
            }
        }
        protected string RadioValue(RadioButton Rbtlst)
        {
            string Value = "";
            if (Rbtlst.Checked == true)
            {
                Value = Rbtlst.Text;
            }
            return Value;
        }
