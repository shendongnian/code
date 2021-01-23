    try
    {
    publishContext = new publishingCompanyEntities();
    comboBox2.DataSource = publishContext.Authors;
    comboBox2.DisplayMember = "FirstName";
    MessageBox.Show(ComboBox2.Text);
    MessageBox.Show(ComboBox2.SelectedValue.ToString);
    }
    catch(Exception ex)
    {
    }
