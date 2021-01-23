    publishContext = new publishingCompanyEntities();
    comboBox2.DataSource = publishContext.Authors;
    comboBox2.DisplayMember = "FirstName";
    comboBox2.DataBindings.Add("SelectedValue", tablename, "FirstName");
    
