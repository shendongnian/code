    public string ReturnDotSuffix(string strValue, int iFontSize, int iWidth)
    {
        string strReturnValue = string.Empty;
        try
        {
            CommonLib objCommonLib = new CommonLib();
            strReturnValue = objCommonLib.SuffixDots(strValue, iFontSize, iWidth);
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return strReturnValue;
    }
