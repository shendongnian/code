	String command = "SELECT b.ID,b.VERANSTALTER, rr.VON ,rr.BIS, b.THEMA, b.STORNO, ra.BEZEICHNUNG from BUCHUNG b JOIN RESERVIERUNGRAUM rr on rr.BUCHUNG_ID = b.ID JOIN RAUM ra on ra.ID = rr.RAUM_ID WHERE b.UPDATE_DATE BETWEEN DATEADD (DAY , -20 , getdate()) AND getdate() AND b.BOOKVERNR = 0";
	SqlCommand cmd = new SqlCommand(command, new SqlConnection(GetConnectionString()));
	connection.Open();
	
    DataTable dt = new DataTable();
    dt.Load(cmd.ExecuteReader());
   
    var bookingupdate = dt.Rows.OfType<DataRow>().Select (row => 
						new BookingUpdate
						{
							bookingID = Convert.ToInt32(row["ID"]),
							fullUserName = row["VERANSTALTER"].ToString(),
							newStart = (DateTime)row["VON"],
							newEnd = (DateTime)row["BIS"],
							newSubject = row["THEMA"].ToString(),
							newlocation = row["BEZEICHNUNG"].ToString(),
							deleted = row["STORNO"].ToString() != null // note that this line makes no sense. If you can call `ToString` on an object, it is not 'null'
						}).ToArray();
						
	return bookingupdate;
