    //Declaring the datasource.
    SqlDataSource SDSBooking= new SqlDataSource();
    //Providing the delete command.
    SDSBooking.DeleteCommand = "DELETE FROM Tbl_Booking WHERE BookingID_PK = @BookingID_PK";
    
    //Adding the parameter for deleting the record.
    SDSBooking.DeleteParameters.Add("BookingID_PK", GVMyBookings.Rows[e.RowIndex].Cells[1].Text);
    //Providing the connection string.
    SDSBooking.ConnectionString = connstring;
    //Executing the delete method of the SqlDataSouce. 
    //It is this line that will actually delete your record.
    SDSBooking.Delete();
