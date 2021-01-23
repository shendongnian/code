    public BookingUpdate[] getBookingUpdates(string token)
    {
    String command = "SELECT b.ID,b.VERANSTALTER, rr.VON ,rr.BIS, b.THEMA, b.STORNO, ra.BEZEICHNUNG from BUCHUNG b JOIN RESERVIERUNGRAUM rr on rr.BUCHUNG_ID = b.ID JOIN RAUM ra on ra.ID = rr.RAUM_ID WHERE b.UPDATE_DATE BETWEEN DATEADD (DAY , -20 , getdate()) AND getdate() AND b.BOOKVERNR = 0";
    SqlConnection connection = new SqlConnection(GetConnectionString());
    connection.Open();
    try
    {
        SqlCommand cmd = new SqlCommand(command, connection);
        SqlDataReader rdr = null;
        int count = 0;
        rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);
                count = dt.Rows.Count;
                BookingUpdate[] bookingupdate = new BookingUpdate[count];
                for (int c = 0; c < count; c++)
                {
                    bookingupdate[c].bookingID = (long)rdr["ID"]; // <---- Error is here
                    bookingupdate[c].fullUserName = rdr["VERANSTALTER"].ToString();
                    bookingupdate[c].newStart = (DateTime)rdr["VON"];
                    bookingupdate[c].newStart = (DateTime)rdr["BIS"];
                    bookingupdate[c].newSubject = rdr["THEMA"].ToString();
                    bookingupdate[c].newlocation = rdr["BEZEICHNUNG"].ToString();
                    if (rdr["STORNO"].ToString() != null)
                    {
                        bookingupdate[c].deleted = true;
                    }
                    else
                    {
                        bookingupdate[c].deleted = false;
                    }
                }
            }
    }
    catch (Exception ex)
    {
        log.Error(ex.Message + "\n\rStackTrace:\n\r" + ex.StackTrace);
    }
    finally
    {
        connection.Close();
    }
    return bookingupdate;
}
