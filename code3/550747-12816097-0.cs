    public static bool ValidateDate(string txtDate, string sDateFormat, ref string sErrMsg, ref DateTime dtDate)
            {
                if (txtDate == "")
                {
                    sErrMsg = "Please Enter Date";
                    return false;
                }
                else
                {
                    System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
                    dateInfo.ShortDatePattern = sDateFormat;
    
                    try
                    {
                        dtDate = Convert.ToDateTime(txtDate, dateInfo);
                        return true;
                    }
                    catch
                    {
                        sErrMsg = "Please Enter Date In Correct Format";
                        return false;
                    }
                }
            }  
