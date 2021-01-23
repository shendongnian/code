    try
    {
    publishContext = new publishingCompanyEntities();
    comboBox2.DisplayMember = "FirstName";
    comboBox2.DataSource = publishContext.Authors.ToList();
    MessageBox.Show(publishContext.Authors.Count().ToString());
    }
    catch(Exception ex)
    {
    }
