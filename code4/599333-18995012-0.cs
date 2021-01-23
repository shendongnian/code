           if ((!e.Value.Equals("OK")) && e.ColumnIndex == 6)
            {
                e.CellStyle.WrapMode = DataGridViewTriState.True;
                //dgvObjetivos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvObjetivos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
