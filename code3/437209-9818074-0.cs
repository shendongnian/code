    public void GetData_BookingsGridView
    {
       .......//your code
       BookingsGridView.DataSource=dt;
       BookingsGridView.DataBind();
    }
    public void DeleteBookingGridView_Row()
    { 
      //code for deleting gridview rows.
      //now call GetData_BookingsGridView function to refresh GridView
      GetData_BookingsGridView();
    }
