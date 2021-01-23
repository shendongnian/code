      foreach (DataGridViewRow r in dgvStatus.Rows) {
           if (r.Index == 0) {
               continue;
            }
                foreach (DataGridViewCell c in r.Cells) {                    
                    if c.OwningColumn is DataGridViewCheckBoxColumn) {
                        continue;
                    }
                    c.Value = "";
                }
            }
