    var serialPortInfo = "GPS:050.1347,N,00007.3612,WMAG:+231\r\n";
    
    private List<string> value1 = new List<string>();
    private List<string> value2 = new List<string>();
    private List<string> value3 = new List<string>();
    
    private void populateValues(string s)
    {
        // this should give an array of the following: 
        // values[0] = "050.1347"
        // values[1] = "N"
        // values[2] = "00007.3612"
        // values[3] = "WMAG:+231"
        //
        var values = (s.Substring(4, (s.Length - 8))).Split(','); 
    
        // populate lists
        //
        value1.Add(values[0]);
        value2.Add(values[2]); 
        value3.Add(values[3].Substring(6, 3));
    }
                
    //usage
    populateValues(serialPortInfo);
