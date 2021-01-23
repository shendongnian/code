        private void dgvApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvApps.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
            {
                if (dgvApps.CurrentCell.IsInEditMode)
                {
                    if (dgvApps.IsCurrentCellDirty)
                    {
                        dgvApps.EndEdit();
                    }
                }
            }
        }
        private void dgvApps_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
              // handle value changed.....
        }
