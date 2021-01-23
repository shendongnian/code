    if (selectedTrack.artists.Count > 1) 
                { 
                    string _rA = "Various Artists"; 
                } 
                else 
                { 
                    for (int i = 0; i <= selectedTrack.artists.Count; i++) 
                    { 
                        string _rA = selectedTrack.artists.name; //Unable to access name vaule here 
                    } 
                } 
