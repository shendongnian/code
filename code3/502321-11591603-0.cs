    void ShowCustomGrid(List<MyEntityRecord> aList)
    {
        MyGrid.Columns.Clear();
        MyGrid.Rows.Clear();
        for(int loop=0;loop<aList.Count;loop++)
        {
            MyGrid.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()));
            MyGrid.Columns[loop].Text=aList[loop].KeyName;
            if(aList[loop].KeyOrder<0) MyGrid.Columns[loop].Visible=false;
        }
        //Now that all columns have been added, change the display index
        for(int loop=0;loop<aList.Count;loop++)
        {
             if(aList[loop].KeyOrder>=0) MyGrid.Columns[loop].DisplayIndex=aList[loop].KeyOrder;
        }
        //Finally, put the values
        MyGrid.Rows.Add();
        for(int loop=0;loop<aList.Count;loop++)
        {
            if(aList[loop].KeyOrder>=0) MyGrid.Rows[0].Cells[loop].Value=aList[loop].KeyValue;
        }
    }
