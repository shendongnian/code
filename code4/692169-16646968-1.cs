    DataSet ds = new DataSet();// SQL STUFF
    SqlConnection con = new SqlConnection(ConnectionString);
    SqlDataAdapter da = new SqlDataAdapter("SELECT ProcessName FROM ApplicationProcesses", con);
    // since you start from SqlDataAdapter I'm continue from there..           
    da.Fill(ds, "ProcessNames");
    // get the process in the database to a array
    string[] preocesArray = ds.Tables["ProcessNames"]
            .AsEnumerable()
            .Select(row => row.Field<string>("ProcessName"))
            .ToArray();
    
    // kill the process if it is in the list 
    var runningProceses = System.Diagnostics.Process.GetProcesses();
    for (int i = 0; i < runningProceses.Length; i++)
    {
        if (preocesArray.Contains(runningProceses[i].ProcessName))
        {
            runningProceses[i].Kill(); //KILLS THE PROCESSES
        }
    }
               
