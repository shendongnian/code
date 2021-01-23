    protected void linkAddAmount_Click(object sender, EventArgs e)
            {
                int count = 0;
    
                if (ViewState["ButtonCount"] != null)
                {
                    count = (int)ViewState["ButtonCount"];
                }
    
                count++;
                ViewState["ButtonCount"] = count;
    
                for (int i = 0; i < count; i++)
                {
                    AmountUpdatePanel.ContentTemplateContainer.Controls.Add(new LiteralControl("<span>From:&nbsp;</span>"));
                    TextBox textbox1 = new TextBox();
                    textbox1.ID = "txtAmountFrom" + i;
                    textbox1.Attributes.Add("class", "ShortTextbox");
    		    if (!string.IsNullOrEmpty(Request.Form["txtAmountFrom" + i.ToString()]))
                    {
    		      textbox1.Text = Request.Form["txtAmountFrom" + i.ToString()];
                    }
                    AmountUpdatePanel.ContentTemplateContainer.Controls.Add(textbox1);
                }
            }
 
