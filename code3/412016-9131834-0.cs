    foreach (var coordinate in coordinates.Descendants())
        {
        foreach (var element in coordinate.Elements("description"))
        {
            	string Links = element.Value;                 
            	StreamWriter1.WriteLine(Links + Environment.NewLine );
        }
            	foreach (var element in coordinate.Elements("guid"))
        {
            	string Links = element.Value;                 
            	StreamWriter1.WriteLine(Links + Environment.NewLine );
        }	
        //.................			
        }
