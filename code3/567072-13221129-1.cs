    bool matchIt(string input)//returns true|false for a match
    {
        if(input=="0")return false;//cuz you dont want to match 0
        string[] parts=input.Split(new string[] { ",","-" }, StringSplitOptions.None);//split them
        int prev=int.Parse(parts[0]);
        foreach(string s in parts)
        {
        if(prev>int.Parse(s))return false;
        prev=int.Parse(s);
        }
        return true;
    }
