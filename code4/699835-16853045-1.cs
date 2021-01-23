    OleDbCommand com = new OleDbCommand("INSERT INTO Debrief ([Debrief_Date], [Task], [DoneName]) VALUES (@Debrief_Date, @Task, @DoneName)", Program.DB_CONNECTION);
    com.Parameters.Add(new OleDbParameter("@Debrief_Date", OledbType.DateTime)).Value = DateTime.Today.Date;
    com.Parameters.Add(new OleDbParameter("@Task", OledbType.VarChar, 30)).Value = checkBox.Text;
    com.Parameters.Add(new OleDbParameter("@DoneName", OledbType.VarChar, 30)).Value = checkBox.Text;
    Program.DB_CONNECTION.Open();
    com.ExecuteNonQuery();
