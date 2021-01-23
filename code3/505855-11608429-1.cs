    public string GetOutPut(int increment)
    {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
       
        string output = string.Empty;
        for(int i=0; i<=increment; i++)
        {
           int index = i*increment;
           if(index>alphabets.Length)
              index = index % alphabets.Length;
           output+= alphabets[index];
        }
        
        return output;
    }
