            if (contactsList.Count > dgvContactsList.Rows.Count)
                dgvContactsList.Rows.Add(
                    contactsList.Count - dgvContactsList.Rows.Count
                );
            int i = 0;
            foreach (Contact c in contactsList)
            {
                dgvContactsList.Rows[i].Cells[0].Value = c.Firstname;
                dgvContactsList.Rows[i].Cells[1].Value = c.Surname;
                dgvContactsList.Rows[i].Cells[2].Value = c.Address;
                i++;
            }
        }
