    enum Color
    {
       Red,
       Orange,
       Yellow,
       Green,
       Blue,
       Purple
    }
    
    bool IsPrimaryColor(Color color)
    {
        switch (color)
        {
        case Color.Red:
        case Color.Yellow:
        case Color.Blue:
            return true;
        default:
            return false;
        }
    }
