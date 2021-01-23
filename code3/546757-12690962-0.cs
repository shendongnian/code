    var testData = new Dictionary<string, int> {
       { "01234567890123", 0 },
       { "012345678901234", 0 },
       { "0123456789012345", 0 },
       { "01234567890123456", 13824 },
       { "012345678901234567", 13879 },
       { "0123456789012345678", 13879 },
       { "01234567890123456789", 13879 },
       { "012345678901234567890", 13879 }
    };
    foreach (var pair in testData){
    	var testCase = pair.Key;
    	var expected = pair.Value;
	
    	var UserData = System.Text.Encoding.ASCII.GetBytes(testCase);
    	if (UserData.GetUpperBound(0) < 17)
    	{
    		Array.Resize(ref UserData, 18);
    	}
    	else if (UserData.GetUpperBound(0) > 17)
    	{
    		Array.Resize(ref UserData, 18);
    	}
    
    	var OrderNumber = System.Text.Encoding.ASCII.GetString(UserData, 0, 8).ToString();
    	var OrderRelease = System.Text.Encoding.ASCII.GetString(UserData, 8, 2).ToString();
    	var HeatNumber = System.Text.Encoding.ASCII.GetString(UserData, 10, 6).ToString();
    	var PieceNumber = UserData[16] * 256 + UserData[17];
	
    	(new { 
    		TestCase = testCase, 
    		OrderNumber, 
    		OrderRelease, 
    		HeatNumber, 
    		PieceNumber, 
    		Success = PieceNumber == expected 
    	}).Dump();	
	
    }
