    var newExpression = new Regex(//@"\bTicket\b.*\bID:\b.*\d{20}", 
    				@"Ticket\s*ID\:\s*(?<num>\(\d{20}\))",
                    RegexOptions.IgnoreCase 
                    | RegexOptions.Singleline
                    | RegexOptions.IgnorePatternWhitespace);
    				
    var items=new List<string>();
    var r=new Random();
    var sb=new StringBuilder();
    var i=0;
    var formats=new []{"TicketID:({0})", "Ticket ID:({0})", "Ticket ID: ({0})", 
                   "Ticket ID: ({0})"};
    for(;i<5;i++){
    	for(var j=0;j<20;j++){
    		sb.Append(r.Next(0,9));
    	}
    	items.Add(string.Format(formats[r.Next(0,4)],sb));
    	sb.Remove(0,20);
    }
    
    for(;i<10;i++){
    	for(var j=0;j<20;j++){
    		sb.Append(r.Next(0,9));
    	}
    	items.Add(string.Format(formats[r.Next(0,2)],sb));
    	sb.Remove(0,20);
    }
    
    for(;i<15;i++){
    	for(var j=0;j<20;j++){
    		sb.Append(r.Next(0,9));
    	}
    	items.Add(string.Format(formats[r.Next(0,2)],sb));
    	sb.Remove(0,20);
    }
    
    foreach(var s in items){
    	var m = newExpression.Match(s);
    	if(m.Success && m.Groups!=null && m.Groups.Count>0){
    		string.Format("{0} - {1}",s,m.Groups["num"].Value).Dump();
    	}
    }
