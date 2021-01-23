    private void dgvAssetCost_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                int percentColumnIndex = 2; //This will represent the column index of the column you want to check.
                int comparisonValue = 100;
    
                    try
                    {
                        if (e.ColumnIndex == PercentColumnIndex)
                        {
                            //Perform your check in here.
                            if (Convert.ToInt32(dgvAssetCost.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) != comparisonValue)
                            {
                                //Do nothing or perform an acrtion when their value is correct.
                                SQLMETHODS.InsertCostSpilt(AssetNumberV, DeptV, CCV, PerCentV); // SQL insert methods, for insering new cost spilts 
    
                                MessageBox.Show("Cost Spilt details have been successfully entered.", "Success!"); // Success Messagebox 
                            }
                            else
                            {
                                //Do something to alert user that their input is incorrect.
                                MessageBox.Show("Cost Spilt details have not been successfully entered!", "Unsuccessful!"); // Success Messagebox 
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                         MessageBox.Show(" Error submitting Cost Spilt details into entry table. processed with error:" + ex.Message); // Error Messagebox 
                    }
                }
            }
