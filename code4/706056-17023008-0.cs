    #region GetPaddedString
    
            private string GetPaddedString(string strValue, int intLength)
            {
                string strReturn = string.Empty;
    
                string _strEmptySpace = " ";
    
                int _vinLength = strValue.Length;
    
                if (_vinLength < intLength)
                {
                    strReturn = strValue + _strEmptySpace.PadRight((intLength - _vinLength));
                }
                else
                {
                    strReturn = strValue;
                }
    
                return strReturn;
    
            }
    
            #endregion
    GetPaddedString("test", 10)
