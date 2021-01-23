        public void dgvSearchSetCurrent(DataGridView oDataGrid, int iCol, string sSearch)
        {
            if (oDataGrid.RowCount > 0)
            {
                bool iFound = false;
                //Search DG column and set select/set the current row
    
                for(int i = 0 ; i < oDataGrid.Rows.Count ; i++)
                {
                    if(oDataGrid.Rows[i].Cell[iCol].Value.ToString() == sSearch)
                    //if(oDataGrid.Rows[i].Cell[iCol].Value.ToString().Contains(sSearch))
                    {
                        iFount = true;
                        oDataGrid.Rows[i].Selected = true;
                        break; //If you want to select all rows contain sSearch, skip this line
                    }
                }
              
                
                //if not found, set current row 0
                if (iFound == false)
                {
                    oDataGrid.Rows[0].Selected = true;
                }
            }
        }
