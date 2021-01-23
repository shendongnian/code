       public DataTable CombineTable(DataTable _dtGridDetails, DataTable _dtSubGridDetails)
       {
           //first create the datatable columns 
           DataSet mydataSet = new DataSet();
           mydataSet.Tables.Add("  ");
           DataTable myDataTable = mydataSet.Tables[0];
           //add left table columns 
           DataColumn[] dcLeftTableColumns = new DataColumn[_dtGridDetails.Columns.Count];
           _dtGridDetails.Columns.CopyTo(dcLeftTableColumns, 0);
           foreach (DataColumn LeftTableColumn in dcLeftTableColumns)
           {
               if (!myDataTable.Columns.Contains(LeftTableColumn.ToString()))
                   myDataTable.Columns.Add(LeftTableColumn.ToString());
           }
           //now add right table columns 
           DataColumn[] dcRightTableColumns = new DataColumn[_dtSubGridDetails.Columns.Count];
           _dtSubGridDetails.Columns.CopyTo(dcRightTableColumns, 0);
           foreach (DataColumn RightTableColumn in dcRightTableColumns)
           {
               if (!myDataTable.Columns.Contains(RightTableColumn.ToString()))
               {
                  // if (RightTableColumn.ToString() != RightPrimaryColumn)
                       myDataTable.Columns.Add(RightTableColumn.ToString());
               }
           }
           //add left-table data to mytable 
           foreach (DataRow LeftTableDataRows in _dtGridDetails.Rows)
           {
               myDataTable.ImportRow(LeftTableDataRows);               
           }
           for (int nIndex = 0; nIndex <= myDataTable.Rows.Count-1; nIndex++)
           {
               if (nIndex == _dtSubGridDetails.Rows.Count)
                   break;
               myDataTable.Rows[nIndex][columnindex] = _dtSubGridDetails.Rows[nIndex][columnindex];           
           } 
           return myDataTable;
       }
