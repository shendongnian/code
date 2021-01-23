    First I have created a new Datatable for our final result:
    DataTable dtInventoryTable = new dtInventoryTable();
    dtInventoryTable.Columns.Add("RateDate", typeof(string));
    dtInventoryTable.Columns.Add("RatePlanId", typeof(string));
    dtInventoryTable.Columns.Add("RoomTypeId", typeof(string));    
    private DataTable DisplayInventoryDetails(DataTable dtInventoryDetail)
    {
    for (int i = 0; i < dtInventoryDetail.Rows.Count; i++)
    {
    String[] row = new String[dtInventoryDetail.Columns.Count];
    String[] row1 = new String[dtInventoryDetail.Columns.Count];
    string str=string.Empty;
    int h=0;
    str = dtInventoryDetail.Rows[i][0].ToString() + " - " +dtInventoryDetail.Rows[i]0].ToString();                                                                                  
    for (int j = i+1;j< dtInventoryDetail.Rows.Count; j++)
    {                
    for (int x = 1; x < dtInventoryDetail.Columns.Count; x++)
    {
     row[x] = dtInventoryDetail.Rows[i][x].ToString();
     }
     for (int y = 1; y < dtInventoryDetail.Columns.Count; y++)
     {
     row1[y] = dtInventoryDetail.Rows[j][y].ToString();
     }
     bool result = ArraysEqual(row, row1);
            
     if (!result)
     {
     dtInventoryTable = GetRoomRateTable(row, str);
     i = j-1;
     h = j;
     break;
     }
     else
     str= dtInventoryDetail.Rows[i][0].ToString() + " - " + dtInventoryDetail.Rows[j][0].ToString();
     h = j;
     }
     }
     if (h >= dtInventoryDetail.Rows.Count-1)
     {
     dtInventoryTable = GetRoomRateTable(row, str);
      break;
      }
          
      }
      return dtInventoryTable;
      }  
       private DataTable GetRoomRateTable(String[] row,string str)
      {
        row[0] = str;
        dtInventoryTable.LoadDataRow(row, true);
        return dtInventoryTable;
      }         
