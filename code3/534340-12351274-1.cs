    void checkLenghth()
    {
        decimal value = 2.15;
        string stringDecimal = value.ToString();
        string[] splitStrings = stringDecimal.Split('.');
        if (splitStrings[1] > 3)
        MessageBox("Its wrong!"); 
    }
