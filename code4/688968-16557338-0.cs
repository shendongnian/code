    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
     {
     try
     {
     
     OleDbConnection conn = new OleDbConnection    ("Provider=Microsoft.Jet.OLEDB.4.0,DataSource=C:\\Users\\jd\\Desktop\\Attendance.mdb");
     con.open();
     OleDbCommand cmd = new OleDbCommand("SELECT * FROM Attendance_Details WHERE Date_Entry=@dtpDate", conn);
     cmd.Parameters.Addwithvalue("@dtpDate", dateTimePicker1.Value);
     cmd.CommandType = CommandType.Text;
     OleDbDataAdapter da = new OleDbDataAdapter(cmd);
     DataSet ds = new DataSet();
     da.Fill(ds);
     txtDate.Text = ds.Tables[0].Rows[0][0].ToString();
     txtEmpNo.Text = ds.Tables[0].Rows[0][1].ToString();
     txtEmpName.Text = ds.Tables[0].Rows[0][2].ToString();
     txtInTime.Text = ds.Tables[0].Rows[0][3].ToString();
     txtOutTime.Text = ds.Tables[0].Rows[0][4].ToString();
     con.close();
     }
     catch (Exception ex)
     {
     MessageBox.Show(ex.Message);
     }
     finally
     {
       con.close();
     }
     }
     }
