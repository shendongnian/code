    string founded = FindStringTakeX("UID:   994zxfa6q", "UID:", 9);
    string FindStringTakeX(string strValue,string findKey,int take,bool ignoreWhiteSpace = true)
        {
            int index = strValue.IndexOf(findKey) + findKey.Length;
            if (index >= 0)
            {
                if (ignoreWhiteSpace)
                {
                    while (strValue[index].ToString() == " ")
                    {
                        index++;
                    }
                }
                if(strValue.Length >= index + take)
                {
                    string result = strValue.Substring(index, take);
                    return result;
                }
                
            }
            return string.Empty;
        }
