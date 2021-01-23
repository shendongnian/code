    private void LoadPage(string APageName)
    {
        FAddress = null;
        PlaceholderAddressTemplate.Controls.Clear();
  
        if (!string.IsNullOrEmpty(APageName))
        {
            FAddress = (UserControl)LoadControl(string.Format("~/UserControls/{0}.ascx",
                        APageName));
            if (FAddress != null)
            {
                FAddress.ID = "UserControl1";
    
                PlaceholderAddressTemplate.Controls.Add(FAddress);
                ShowOrHideComponents();
                FAddress.Focus();
            }
            else
                ShowOrHideComponents();
        }
        else
        ShowOrHideComponents();
    }
