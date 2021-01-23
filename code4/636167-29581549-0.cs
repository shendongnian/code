    DataSet.yourRow iAmARow;
    try
    {
       //you must to edit this line depending of the control that
       //you 're using on your form
       iAMARow = 
       this.yourDataGridView.yourTable.FindByBooking(nameOfTheColumn);
       
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
