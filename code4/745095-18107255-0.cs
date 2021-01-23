    void Main()
    {
        int intColor = 8689404;
        var c = Color.FromArgb(255, Color.FromArgb(intColor));
    
        IsEqual(c, intColor);    //prints True
    }
    //Assumes A = 255
    bool IsEqual(Color c, int i)
    {
        int j = (int)(c.ToArgb() & 0x00FFFFFF);
        return i == j;
    }
