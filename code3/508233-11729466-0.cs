    class MyData{
       public DataSet ds;
       public MyData(string DataSetName)
       {
           ds = Session[DataSetName] as DataSet;
       }
    }
    private void btnclick()
    {
       MyData myd = new MyData("test");
       myQueue.Enqueue(myd);
       Process(myQueue.Dequeue);
    }
    public void Process(MyData d)
    {
       DataSet ds = d.ds;
       PerformFinalTransformation(ds);
       foreach (DataTable dt in ds.Tables)
       {
          foreach (DataRow dr in dt.Rows)
          {
             CallCustomSqlFunction(dr);
          }
       }
    }
