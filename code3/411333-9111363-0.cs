    public void DisplayRev(string str)      
    {         
        if(str.Length > 0)             
            DisplayRev(str.Substring(1, str.Length-1));
        else
             return; 
        Console.Write(str[0]);     
    }
