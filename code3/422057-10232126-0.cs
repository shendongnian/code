    private void btnNext_Click(object sender, EventArgs e)
            {
                //Get number of records displayed in the data grid view and subtract one to keep in line with index that starts with 0
                int numOfRows = dataGrdViewCases.Rows.Count - 1;
    
                //Get current row selected
                int index = dataGrdViewCases.SelectedRows[0].Index;
    
                // Determine if the next record exists or cycle back to the first record in the set
                if (index < numOfRows)
                {
                    //Change the selected row to next row down in the data set
                    dataGrdViewCases.CurrentCell = dataGrdViewCases[0, index + 1];
                }
                else
                {
                    // Select the first record of the data set
                    dataGrdViewCases.CurrentCell = dataGrdViewCases[0, 0];
                }
            }
    
            private void btnPrevious_Click(object sender, EventArgs e)
            {
                //Get number of records displayed in the data grid view and subtract one to keep in line with index that starts with 0
                int numOfRows = dataGrdViewCases.Rows.Count - 1;
    
                //Get current row selected
                int index = dataGrdViewCases.SelectedRows[0].Index;
    
                // Determine if the previous record exists or cycle back to the last record in the set
                if (index != 0)
                {
                    //Change the selected row to next row down in the data set
                    dataGrdViewCases.CurrentCell = dataGrdViewCases[0, index - 1];
                }
                else
                {
                    // Select the first record of the data set
                    dataGrdViewCases.CurrentCell = dataGrdViewCases[0, numOfRows];
                }
            }
