    protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //set the appropriate conditions for your solution
            if (true)
            {
                //create text box
                TextBox txtNewField = new TextBox();
                txtNewField.ID = "txtNewField";
                //create and initialize validator
                RegularExpressionValidator regexR1 = new RegularExpressionValidator();
                regexR1.ValidationExpression = "set the regex here";
                regexR1.ControlToValidate = txtNewField.ID;
                regexR1.ErrorMessage = "you are doing something wrong";
                //add both of these to page wehre needed. 
                //I assume there is a panel control where you are adding these 
                //but you can customize it more
                pnlFields.Controls.Add(txtNewField);
                pnlFields.Controls.Add(regexR1);
            }
        }
