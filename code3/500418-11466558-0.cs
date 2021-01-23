    private void dgrvUserProfileView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        int CheckedCount = 0;
    
        //Make sure you have set True Value/ false Value property of check box column to 1/0 or true/false resp.
        //Lets say your column 5th(namely Department) is a checked box column
        if (dgrvUserProfileView.Columns[e.ColumnIndex].Name == "Department")
        {
            for (int i = 0; i <= dgrvUserProfileView.Rows.Count - 1; i++)
            {
                if (Convert.ToBoolean(dgrvUserProfileView.Rows[i].Cells["Department"].Value) == true)
                {
                    CheckedCount = CheckedCount + 1;
                }
            }
    
            if (CheckedCount == 1)
            {
                for (int i = 0; i <= dgrvUserProfileView.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dgrvUserProfileView.Rows[i].Cells["Department"].Value) == true)
                    {
                        dgrvUserProfileView.Rows[i].Cells["Department"].ReadOnly = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i <= dgrvUserProfileView.Rows.Count - 1; i++)
                {
                    dgrvUserProfileView.Rows[i].Cells["Department"].ReadOnly = false;
                }
            }
        }
    }
