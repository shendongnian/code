      private void selectRow(string studentName, string date)
        {
            int i = 0;
            foreach (DataGridViewRow r in dgvPontengHistory.Rows)
            {
                if (r.Cells["student_name"] == null) { throw("can't find cell"); }
                if(r.Cells["student_name"].Value == null) { throw("cell has no value"); }
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
