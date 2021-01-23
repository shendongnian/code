    public void createSettingsTable()
    {
    	string filename = "\\my documents\\CCRDB.SDF"; // <- Here
    	string conStr = "Data Source = " + filename;
    	try
    	{
    		using (SqlCeConnection con = new SqlCeConnection(conStr)) // <- Here
    		{
    			con.Open();
    			using (SqlCeCommand com =  new SqlCeCommand("create table ccr_settings (setting_id INT IDENTITY NOT NULL PRIMARY KEY,  setting_name varchar(40) not null, setting_value(63) varchar not null)", con))
    	   		{
          				com.ExecuteNonQuery();
       			}
    			//con.Close(); // this is not needed
    		}
    	}
    	catch (Exception ex)
    	{
    		CCR.ExceptionHandler(ex, "createSettingsTable");
    	}
    }
