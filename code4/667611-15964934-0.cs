    protected void CustomerDetailView_PageIndexChanging(
      object sender, DetailsViewPageEventArgs e)
    {
        // Cancel the paging operation if the user tries to 
        // navigate to another record while in edit mode.
        if (CustomerDetailView.CurrentMode == DetailsViewMode.Edit)
        {
            e.Cancel = true;
            // Display an error message.
            ErrorMessageLabel.Text = 
              "You cannot navigate to another record while in edit mode.";
        }
    }
