        List<char> lstGetDecrName(List<char> lstVal)//entry point, returns decreased value
        {
            if (lstVal.Contains('-'))
            {
                return "-".ToList();
            }
            List<char> lstTmp = lstVal;
            subCheckEmpty(ref lstTmp);
            switch (lstTmp.Count)
            {
                case 0:
                    lstTmp.Add('-');
                    return lstTmp;
                case 1:
                    if (lstTmp[0] == '-')
                    {
                        return lstTmp;
                    }
                    break;
                case 2:
                    if (lstTmp[1] == '0')
                    {
                        if (lstTmp[0] == '1')
                        {
                            lstTmp.Clear();
                            lstTmp.Add('9');
                            return lstTmp;
                        }
                        if (lstTmp[0] == 'A')
                        {
                            lstTmp.Clear();
                            lstTmp.Add('-');
                            return lstTmp;
                        }
                    }
                    if (lstTmp[1] == 'A')
                    {
                        if (lstTmp[0] == 'A')
                        {
                            lstTmp.Clear();
                            lstTmp.Add('Z');
                            return lstTmp;
                        }
                    }
                    break;
            }
            List<char> lstValue = new List<char>();
            switch (lstTmp.Last())
            {
                case 'A':
                    lstValue = lstGetDecrTemp('Z', lstTmp, lstVal);
                    break;
                case 'a':
                    lstValue = lstGetDecrTemp('z', lstTmp, lstVal);
                    break;
                case '0':
                    lstValue = lstGetDecrTemp('9', lstTmp, lstVal);
                    break;
                default:
                    char tmp = (char)(lstTmp.Last() - 1);
                    lstTmp.RemoveAt(lstTmp.Count - 1);
                    lstTmp.Add(tmp);
                    subCheckEmpty(ref lstTmp);
                    lstValue = lstTmp;
                    break;
            }
            lstGetDecrSkipValue(lstValue);
            return lstValue;
        }
        List<char> lstGetDecrSkipValue(List<char> lstValue)
        {
            bool blnSkip = false;
            foreach (char tmpChar in lstValue)
            {
                if (lstChars.Contains(tmpChar))
                {
                    blnSkip = true;
                    break;
                }
            }
            if (blnSkip)
            {
                lstValue = lstGetDecrName(lstValue);
            }
            return lstValue;
        }
        void subCheckEmpty(ref List<char> lstTmp)
        {
            bool blnFirst = true;
            int i = -1;
            foreach (char tmpChar in lstTmp)
            {
                if (char.IsDigit(tmpChar) && blnFirst)
                {
                    i = tmpChar == '0' ? lstTmp.IndexOf(tmpChar) : -1;
                    if (tmpChar == '0')
                    {
                        i = lstTmp.IndexOf(tmpChar);
                    }
                    blnFirst = false;
                }
            }
            if (!blnFirst && i != -1)
            {
                lstTmp.RemoveAt(i);
                subCheckEmpty(ref lstTmp);
            }
        }
        List<char> lstGetDecrTemp(char chrTemp, List<char> lstTmp, List<char> lstVal)//shifting places eg unit to ten,etc.
        {
            if (lstTmp.Count == 1)
            {
                lstTmp.Clear();
                lstTmp.Add('-');
                return lstTmp;
            }
            lstTmp.RemoveAt(lstTmp.Count - 1);
            lstVal = lstGetDecrName(lstTmp);
            lstVal.Insert(lstVal.Count, chrTemp);
            subCheckEmpty(ref lstVal);
            return lstVal;
        }
