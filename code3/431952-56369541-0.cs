    public string tab(string s, int w)
    {
        //w is the desired width
        int stringwidth = s.Length;
        int i;
        string resultstring = s;
        for(i=0;i<=(w-stringwidth)/8;i++)
        {
            resultstring = resultstring + "\t";
        }
        return resultstring;
     }
