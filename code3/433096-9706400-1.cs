     protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (rblCreat.SelectedIndex == 1)
            {
                if (e.Value.Length > 0)
                {
                    e.IsValid = true;
                }
                else
                {
                    e.IsValid = false;
                }
            }
            else {
                e.IsValid = true;
            }
        }
