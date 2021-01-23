    string _rA;
    
    if (selectedTrack.artists.Count > 1) 
                
    { 
    
    
    	for (int i = 0; i <= selectedTrack.artists.Count; i++)
    		_rA += "," + selectedTrack.artists[i].name; 
    }
    else
    {
    _rA = "Various Artists"; 
    
    
    }
