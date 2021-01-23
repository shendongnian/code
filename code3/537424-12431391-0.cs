    if (IsPostBack)
        {
            Boolean bFileOK = false;
    
            if (fulReagentImg.HasFile)
            {
                String sFileExtension = System.IO.Path.GetExtension(fulReagentImg.FileName).ToLower();
                String sFileExtensionLabel = sFileExtension;
                lblFileExtension.Text = sFileExtensionLabel;
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (sFileExtension == allowedExtensions[i])
                    {
                        bFileOK = true;
                        break;
                    }
                    else
                    {
                        lblException.Text = "Can only upload .gif, .png, .jpeg, .jpg";
                        lblException.CssClass = "red";
                    }
    
    }
