                if (i >= dgvContactsList.Rows.Count)
                    dgvContactsList.Rows.Add();
                dgvContactsList.Rows[i].Cells[0].Value = c.Firstname;
                dgvContactsList.Rows[i].Cells[1].Value = c.Surname;
                dgvContactsList.Rows[i].Cells[2].Value = c.Address;
                i++;
            }
        }
