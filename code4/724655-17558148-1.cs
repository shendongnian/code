    public bool IntErrorCheckMethod(string xTempVal, out int tempNum)
    {
        tempNum = 0;
        bool errorFlag = false;
        try
        {
            tempNum = int.Parse(xTempVal);
        }
        catch(FormatException)
        {
            errorFlag = true;
            tempNum = 999;
        }
        return errorFlag;
    }
