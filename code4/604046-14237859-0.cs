	Encoding iso88591 = Encoding.GetEncoding(28591);
	Encoding w1252 = Encoding.GetEncoding(1252);
	
	//
	string pwd = "ÖFÖæ\u00966"; //The SPA control character will not survice a Stackoverflow post
								//So I use \u0096 to represent it
								
	string result = w1252.GetString(iso88591.GetBytes(pwd)); //"ÖFÖæ–6"
	
	string original = iso88591.GetString(w1252.GetBytes(result)); //"ÖFÖæ6" with the hidden control character before 6
    Console.WriteLine(result == "ÖFÖæ–6"); //True
    Console.WriteLine(original == "ÖFÖæ\u00966"); //True
