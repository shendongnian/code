    public bool IsMale
    { 
        get { return Sex == "M"; }
        set 
        {  
            if (value)
                Sex = "M";
            else
                Sex = "F";
        }
    }
