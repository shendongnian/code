    var MyConString = "server=localhost;" +
                   "database=sentiwornet;" + "password=zia;" +
                   "User Id=root;";
    var connection = new MySqlConnection(MyConString);
    
    //Each line in the array will probably be one paragraph.
    var fileLines = File.ReadAllLines("D:\\input.txt");
    foreach (var line in fileLines)
    {
    		//Format your line into words by removing punctuation. I'm not going to bother
    		//with that code because it is trivial.
    		//var csv = line.Split(' ');
    	
    	    var command = connection.CreateCommand();
                        command.CommandText = "exec spGetWordScores";
                        command.Parameters.AddWithValue("@csv", csv);
    		var ds = command.ExecuteDataSet();
    		
    		//Now you have a DataSet with your word scores. do with them what you will.
    }
