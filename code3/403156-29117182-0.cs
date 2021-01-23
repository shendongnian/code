      DataGridViewComboBoxColumn ColDryg =
     (DataGridViewComboBoxColumn)Gv_dtails.Columns["ColDryg"];
                 ColDryg.DataSource = db.Drugs.ToList();
                 ColDryg.ValueMember = "Id";
                 ColDryg.DisplayMember ="Arabic_name";
