                    EditMemberForm getEditMemberForm = new EditMemberForm();
                    DataGridViewCell cell = null;                
    
                    foreach (DataGridViewCell selectedCell in MembersGridView.SelectedCells)
                    {
                        cell = selectedCell;
                        break;
                    }
    
                    if (cell != null)
                    {
                        DataGridViewRow row = cell.OwningRow;
    
                        getEditMemberForm.EditFirstNameTextBox.Text = row.Cells["FirstNameColumn"].Value.ToString();
                        getEditMemberForm.EditLastNameTextBox.Text = row.Cells["LastNameColumn"].Value.ToString();
                        getEditMemberForm.EditPersonalIdTextBox.Text = row.Cells["PersonalIdColumn"].Value.ToString();
                        getEditMemberForm.EditCityComboBox.Text = row.Cells["CityColumn"].Value.ToString();
                        getEditMemberForm.EditPhoneNumberTextBox.Text = row.Cells["PhoneNumberColumn"].Value.ToString();
                    }
    
                    getEditMemberForm.ShowDialog();
