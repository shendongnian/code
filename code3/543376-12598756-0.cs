    public List<string>  Test_IsDataLoaded()
    {
       List<string> ReleaseIDList = new List<string>();
        try
        {
            if (GRIDTest.Rows.Count != 0)
            {
                int countvalue = GRIDTest.Rows.Count;
                GRIDTest.Rows[0].WaitForControlReady();
                int nCellCount = GRIDTest.Cells.Count;
                for(int nCount = 0;nCount<nCellCount ;nCount++)
                  {
                        if(nCount %5==0)
                        ReleaseIDList.Add((GRIDTest.Cells[0].GetProperty("Value").ToString()));
                  }
                  
             }
        }
        catch (Exception)
    {
    }
    return ReleaseIDList;  
    }
