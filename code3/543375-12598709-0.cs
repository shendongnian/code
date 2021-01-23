    public List<string>  Test_IsDataLoaded()
        {
            try
            {
                if (GRIDTest.Rows.Count != 0)
                {
                    int countvalue = GRIDTest.Rows.Count;
                    GRIDTest.Rows[0].WaitForControlReady();
    
                    List<string> ReleaseIDList = new List<string>();
    
                    int nCellCount = GRIDTest.Cells.Count;
    
                    for(int nCount = 0;nCount<nCellCount ;nCount++)
                      {
                            if(nCount %5==0)
                            ReleaseIDList.Add((GRIDTest.Cells[0].GetProperty("Value").ToString()));
                      }
                    return ReleaseIDList;    
                 }
    
            }
            catch (Exception)
        {
        }
    
    return new List<string>() ;//<-------here
    }
