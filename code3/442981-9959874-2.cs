    protected void SaveProductsButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in ProductGridview.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                // Have to cast the result of FindControl to the correct type
                TextBox productTextBox = (TextBox)row.FindControl("ProductNameTextBox");
                DropDownList lotNumberDropDownList = (DropDownList)row.FindControl("LotNumberDropDownList");
                FileUpload imageFileUpload = (FileUpload)row.FindControl("ImageFileUpload");
                CheckBox activeCheckBox = (CheckBox)row.FindControl("ActiveCheckBox");
                saveProduct(productTextBox.Text, lotNumberDropDownList.SelectedItem.Text,
                                       imageFileUpload.PostedFile, activeCheckBox.Checked);
            }
        }
    }
