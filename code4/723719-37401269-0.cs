        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Calculate")
            {
                // ...            
                //instead of this...
                TextBox itemsCostTextBox = (TextBox)row.FindControl("ItemCosts");
                //(no need to use row here, just use the reference to the FormView;
                //also no need to add an ID to DynamicControl because it creates
                //its own ID out of the field name and template control name)
    
                //cast like this...
                var itemsCostTextBox = (TextBox)FormView1.FindFieldTemplate("ItemCosts").TemplateControl.FindControl("txtTextBox1");
                //txtTextBox1 is the name of the specific web UI control inside of
                //the DynamicData *.ascx template that you want access to
            }
        }
