    protected void Button1_Click(object sender, EventArgs e)
    {
        if (fileUploadPhoto.HasFile)
        {
            byte[] imageBytes = new byte[fileUploadPhoto.PostedFile.InputStream.Length + 1];
            fileUploadPhoto.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);
        }
    
        Label1.Text = Convert.ToString(a.sell_item(Convert.ToString(TextBoxName.Text), imageBytes, Convert.ToString(TextBoxDescription.Text)));
    
        Label1.Visible = true;
        if (Label1.Visible == true)
        {
            MessageBox.Show("Item has been uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            Response.Redirect("Menu page.aspx");
        }
    }
