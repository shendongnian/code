            private void CheckECName(DataGridViewCellValidatingEventArgs newValue)
            {
                StringBuilder _errMsg = new StringBuilder();
                string _cellMsg = "";
                string _eCon_Name = "";
                DataGridViewCell cell = this.dgEmergencyContact.Rows[newValue.RowIndex].Cells[newValue.ColumnIndex];
                if (!String.IsNullOrEmpty(newValue.FormattedValue.ToString()))
                {
                    _eCon_Name = newValue.FormattedValue.ToString();
                    if (!((_eCon_Name.Trim()).Length == 0))
                    {
                        // Match the regular expression pattern against a text string.
                        // Only alphabetic and space characters
                        //Match m = r.Match(wholeName);
                        //if (!m.Success)
                        if (TestInput.IsFullName(_eCon_Name))
                        {
                            string _cellLabel = "Emergency Conact Name";
                            _cellMsg = "Emergency Contact name";
                            NotifyUserAndContinue(_cellLabel, _cellMsg, newValue);
                            return;
                        }
                        else
                        {
                            _cellMsg = "Emergency Contact name";
                            _errMsg.Append("The Emergency Contact Name: " + _eCon_Name + " is entered incorrectly.");
                            _errMsg.AppendLine("Acceptable format: First Last");
                            _errMsg.AppendLine("\n\tFirst MI Last");
                            _errMsg.AppendLine("\n\tFirst Middle Last");
                            _errMsg.AppendLine("\nNo commas or periods, please.");
                            NotifyUserAndForceRedo(_cellMsg, _errMsg.ToString(), newValue);
                            return;
                        }
                    }
                }
            }
            private void CheckECEmail(DataGridViewCellValidatingEventArgs newValue)
            {
                StringBuilder _errMsg = new StringBuilder();
                string _cellMsg = "";
                string techEmail = newValue.FormattedValue.ToString().Trim(); 
                DataGridViewCell cell = this.dgEmergencyContact.Rows[newValue.RowIndex].Cells[newValue.ColumnIndex];
                if (!(techEmail.Length == 0))
                {
                    // Send the contents of the Personal Email to the tester class
                    if (TestInput.IsEmail(techEmail))
                    {
                        string _cellLabel = "Emergency Conact Email";
                        _cellMsg = "Emergency Contact email address";
                        NotifyUserAndContinue(_cellLabel, _cellMsg, newValue);
                        return;
                    }
                    else
                    {
                        _cellMsg = "Emergency Contact email address";
                        _errMsg.Append("An invalid email address has been entered.");
                        _errMsg.AppendLine("Format email@server.type (jim@place.com)");
                        NotifyUserAndForceRedo(_cellMsg, _errMsg.ToString(), newValue);
                        return;
                    }
                }
            }
            private void CheckECPhone(DataGridViewCellValidatingEventArgs newValue)
            {
                StringBuilder _errMsg = new StringBuilder();
                string _cellMsg = "";
                string techPhone = newValue.FormattedValue.ToString().Trim();
                DataGridViewCell cell = this.dgEmergencyContact.Rows[newValue.RowIndex].Cells[newValue.ColumnIndex];
                if (!(techPhone.Length == 0))
                {
                    // Send the contents of the Personal Phone to the tester class
                    if (TestInput.IsPhone(techPhone))
                    {
                        string _cellLabel = "Emergency Conact Phone";
                        _cellMsg = "Emergency Contact phone number";
                        NotifyUserAndContinue(_cellLabel, _cellMsg, newValue);                
                        return;
                    }
                    else
                    {
                        _cellMsg = "Emergency Contact phone number";
                        _errMsg.Append("An invalid phone number has been entered."); 
                        _errMsg.AppendLine("Acceptable formats: 8606782345");
                        _errMsg.AppendLine("\t860-678-2345");
                        _errMsg.AppendLine("\t(860) 678-2345");
                        _errMsg.AppendLine("\t(860) 678 - 2345");
                        NotifyUserAndForceRedo(_cellMsg, _errMsg.ToString(), newValue);
                        return;
                    }
                }
            }
            private void NotifyUserAndForceRedo(string cellMessage, string errorMessage, DataGridViewCellValidatingEventArgs newValue)
            {
                DataGridViewCell cell = this.dgEmergencyContact.Rows[newValue.RowIndex].Cells[newValue.ColumnIndex];
                MessageBox.Show(errorMessage);
                dgEmergencyContact.Rows[cell.RowIndex].ErrorText = String.Format("{0} is entered incorrectly", cellMessage);
                cell.ErrorText = String.Format("{0} is entered incorrectly", cellMessage);
                try
                {
                    dgEmergencyContact.EditingControl.BackColor = Color.OrangeRed;
                }
                catch (Exception)
                {
                }            
                newValue.Cancel = true;
            }
            private void NotifyUserAndContinue(string cellLabel, string cellMessage, DataGridViewCellValidatingEventArgs newValue)
            {
                DataGridViewCell cell = this.dgEmergencyContact.Rows[newValue.RowIndex].Cells[newValue.ColumnIndex];
                string _goodMsg = String.Format("A valid {0} has been entered.", cellMessage);
                AutoClosingMessageBox.Show(cellMessage, cellLabel, 2500);
                cell.Style.BackColor = Color.White;
                cell.ErrorText = "";
                dgEmergencyContact.Rows[cell.RowIndex].ErrorText = "";
            }
