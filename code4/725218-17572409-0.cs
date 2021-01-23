    public void Confirm_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
              // Many validations here
              // Keep file in Session or in a temporary storage
        }
    }
    
    public void Save_Click(object sender, EventArgs e)
    {
        // Always return false here
        if (FileUpload1.HasFile)
        {
              // Many validations here
              // Take the file from session or temporary storage and save it
        }
    }
