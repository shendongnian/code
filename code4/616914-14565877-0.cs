    DialogResult result = MessageBox.Show("Do you want to save changes ?", "Save",
                                       MessageBoxButtons.YesNoCancel,
                                       MessageBoxIcon.Information,
                                       MessageBoxDefaultButton.Button3);
    
                switch (result)
                {
    
                    case DialogResult.Yes: 
                        closingPending = true;
                        MessageBox.Show("To Do - validate and save");
                        break;
    
                    case DialogResult.No: 
                        closingPending = true;
                        Application.Exit();
                        break;
    
                    case DialogResult.Cancel:
                        closingPending = true;
                        e.Cancel = true;
                        break;
                }
