        protected void cvtbProduct_Email_OnServerValidate(object sender, ServerValidateEventArgs args)
        {
            var emailList = (TextBox) RadGrid1.MasterTableView.GetInsertItem().FindControl("Product_Email");
            
            if (string.IsNullOrEmpty(emailList.Text))
            {
                args.IsValid = false;
                return;
            }
            //you don't need to check if it has the seperator in it
            var emails = emailList.Text.Split(';');
            
            foreach (var email in emails)
            {
                //the @ before a string removes the need to double up on '\'
                //you were missing a '\' before the .
                var valid = Regex.IsMatch(email, @"\w+([-+.']\w+)*@ABCCompany\.com");
                if (!valid)
                {
                    args.IsValid = false;
                    return; //don't check anymore
                }
            }
            //all must have passed
            args.IsValid = true;
        }
