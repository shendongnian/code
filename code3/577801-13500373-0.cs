    public Dictionary<char,int> Histogram( String myString )
    {
        Dictionary<char,int> hist = new Dictionary<char,int>()
        if( !String.IsNullOrEmpty(myString) )
        {
            for( int i = 0; i < myString.Length; i++ )
            {
                char c = myString[i];
                
                if(hist.ContainsKey(c))
                {
                    hist[c] = hist[c] + 1;
                }
                else
                {
                    hist.Add(c,1);
                }
            }
        }
        return hist;
    }
