    private void selectRow(string studentName, string date)
    {
        int i = 0;
        foreach (DataGridViewRow r in dgvPontengHistory.Rows)
        {
            if(r.Cells["student_name"].Value == null) return;
            if(r.Cells["student_name"].Value.ToString().Contains(studentName)) // error in this line
            {
                if (r.Cells["date"].Value.ToString().Contains(date))
                {
                    dgvPontengHistory.Rows[i].Selected = true;
                    return;
                }
            }
            i++;
        }
    }
