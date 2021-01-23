    foreach (DataGridViewColumn col in grd1.Columns)
    {
        string myCol = col.Name;
        int myColLength = col.Name.Length;
        string myColMonth = myCol.Substring(myColLength - 2);
        int myColMonthIntValue = int.MaxValue;
        if (int.TryParse(myColMonth, out myColMonthIntValue) && myColMonthIntValue <= myMostRecentActualMonth)
        {
            col.ReadOnly = true;
        }
        else
        {
            col.ReadOnly = false;
        }
    }
        
