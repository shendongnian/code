    if (!String.IsNullOrEmpty(EncryptedString))
    {
        for (i = 0; i < EncryptedString.Length; i++)
        {
            try
            {
                TempChar = EncryptedString[i];
                value = (int)TempChar - 120;
                FinalStr = FinalStr + (char)(value);
            }
            catch (System.Exception e)
            {
                // TODO: Exit Function: Warning!!! Need to return the value
                return "";
            }
        }
 
