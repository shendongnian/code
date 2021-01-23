    DataRow[]  ExcelRows;
    ExcelDataTable.Rows.CopyTo(ExcelRows,0);
    
    For(int i=0;i<ExcelRows.Length;i++)//i represents the row
    {
         var oldDate=ExcelRows [i]["DateColumn"].ToString();
         var newDate=Convert.ToDateTime(oldDate);   
         ExcelRows [i]["DateColumn"] = newDate.ToString("yyyy/MM/dd");   
    }  
     bulkCopy.WriteToServer(ExcelRows);
