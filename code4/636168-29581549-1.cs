    DataSet.yourRow iAmARow;
    try
    {
       iAMARow = 
       this.yourDataSet.yourTable.FindByBooking(nameOfTheColumn);
       
       if (iAmARow != null)
       {
           iAmARow.Delete();
           this.yourTableAdapter.Update(this.yourDataSet);
           this.yourDataSet.yourTable.AcceptChanges();
       }
    }
    catch (SqlException ex)
    {
       ex.StackTrace.ToString();
    }   
