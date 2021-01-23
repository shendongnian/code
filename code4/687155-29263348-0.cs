    for (int i = 0; i < AllCriterias.Count; i++)
                {
                    DataGridViewTextBoxCell Cmb1 = (DataGridViewTextBoxCell)DGVEligibilityCriteria.Rows[i].Cells[0];
                    Cmb1.Value = AllCriterias[i].Name;
                    DataGridViewTextBoxCell Cmb2 = (DataGridViewTextBoxCell)DGVEligibilityCriteria.Rows[i].Cells[1];
                    Cmb2.Value = AllCriterias[i].Type;
                    DataGridViewComboBoxCell Cmb = (DataGridViewComboBoxCell)DGVEligibilityCriteria.Rows[i].Cells[2];
                    foreach (var filtervalue in AllCriterias[i].FilterValues)
                    {
                        Cmb.Items.Add(filtervalue);
                    }
                 }
