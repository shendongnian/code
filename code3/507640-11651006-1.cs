    public string ReplaceStirng(string originalSting, string replacedString)
    {
        try
        {
            List<string> subString = originalSting.Split('.').ToList();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < subString.Count - 1; i++)
            {
                stringBuilder.Append(subString[i]);
            }
            stringBuilder.Append(replacedString);
            return stringBuilder.ToString();
        }
        catch (Exception ex)
        {
            if (log.IsErrorEnabled)
                log.Error("[" + System.DateTime.Now.ToString() + "] " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + " :: " + System.Reflection.MethodBase.GetCurrentMethod().Name + " :: ", ex);
                throw;
        }
    }
