    foreach (Control c in this.Controls)
    {
        if (c is ComboBox)
        {
            DataTable dtTemp = DataSet1.Tables[0].Copy();
            (c as ComboBox).DataSource = dtTemp 
            (c as ComboBox).DisplayMember = "Articles";
        }
    }
