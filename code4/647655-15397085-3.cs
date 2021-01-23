    try
    {
    	SqlConnection cn = new SqlConnection("Data Source=.\\SqlExpress;Initial Catalog=AllensCroft;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework;");
    
    	cn.Open();
    	SqlCommand Command;
    	//check if row exists 
    	Command = new SqlCommand("select count(*) from Slots WHERE [Date] = @date AND [RoomID] = @room", cn);
    	Command.Parameters.AddWithValue("date", date);
    	Command.Parameters.AddWithValue("room", rooms_combo.SelectedValue);
    
    	var cnt = Command.ExecuteScalar();
    	if(cnt!=null)
    	{
    		string sqlstr = ""
    		if(Int32.Parse(cnt) > 0)
    		{
    			sqlstr = CreateUpdateStatement(time_began_5,time_finished_5);
    		}
    		else if(Int32.Parse(cnt) = 0)
    		{
    			sqlstr = CreateInsertStatement(time_began_5,time_finished_5);
    		}
    		Command = new SqlCommand(sqlstr, cn);
    		Command.Parameters.AddWithValue("date", date);
    		Command.Parameters.AddWithValue("room", rooms_combo.SelectedValue);
    		Command.ExecuteNonQuery();
    	}
    	try
    	{
    		cn.Close();
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine(e.ToString());
    	}
    }
    catch (Exception e)
    {
    	Console.WriteLine(e.ToString());
    }
