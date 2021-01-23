    public void Caller()
    {
      using(DataSet ds = GetDataSet())
      {
        // code here
      }
    }
    
    public DataSet GetDataSet()
    {
      // don't use a using statement here
      return ds;
    }
