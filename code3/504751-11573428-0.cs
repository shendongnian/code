    if (!IsWorkSaved())
                {
                    if (MessageBox.Show("Would you like to save your work", "Save work", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveWork();
                    }
                }
