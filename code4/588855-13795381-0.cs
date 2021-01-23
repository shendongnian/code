     if (IsPostBack)
        {
            if (!(String.IsNullOrEmpty(txtPassword.Text.Trim())))
            {
                txtPassword.Attributes["value"] = txtPassword.Text;
            }
        }
