    DataGridViewComboBoxColumn subjectsCombo = new DataGridViewComboBoxColumn();
    subjectsCombo.DataPropertyName = "SubjectID";
    subjectsCombo.HeaderText = "Subjects";
    
    
    subjectsCombo.DataSource = dsSched.Tables["Subjects"];
    subjectsCombo.ValueMember = "SubjectID";
    subjectsCombo.DisplayMember = "SubjectText";
    
    cbxSubject.Columns.Add(subjectsCombo);
