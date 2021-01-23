    using(StreamReader lolz = new StreamReader("test.txt"))
    {
       string line;
       string[] lines;
    	    while ((line = lolz .ReadLine()) != null)
    	    {
                    lines = line.Split('|');
    		tasksList.Add(new TaskList(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6]));
    	    }
    }
                 
