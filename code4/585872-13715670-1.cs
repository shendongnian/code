            bool blnIsValid = false;
            int intValue = 0;
            int[] intWeights = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
            if (p_strVin == null)
            {
                return false;
            }
            else if (p_strVin.Length != 17)
            {
                return blnIsValid;
            }
            p_strVin = p_strVin.ToUpper().Trim();
            int intCheckValue = 0;
            char check = p_strVin[8];
            char year = p_strVin[9];
            if (!char.IsDigit(check) && check != 'X')
            {
                return blnIsValid;
            }
            else
            {
                if (check != 'X')
                {
                    char[] d = new char[] { check };
                    var bytes = Encoding.UTF8.GetBytes(d);
                    intCheckValue = int.Parse(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                }
                else
                {
                    intCheckValue = 10;
                }
            }
            
            Dictionary<char, int> replaceValues = new Dictionary<char, int>();
            replaceValues.Add('A', 1);
            replaceValues.Add('B', 2);
            replaceValues.Add('C', 3);
            replaceValues.Add('D', 4);
            replaceValues.Add('E', 5);
            replaceValues.Add('F', 6);
            replaceValues.Add('G', 7);
            replaceValues.Add('H', 8);
            replaceValues.Add('J', 1);
            replaceValues.Add('K', 2);
            replaceValues.Add('L', 3);
            replaceValues.Add('M', 4);
            replaceValues.Add('N', 5);
            replaceValues.Add('P', 7);
            replaceValues.Add('R', 9);
            replaceValues.Add('S', 2);
            replaceValues.Add('T', 3);
            replaceValues.Add('U', 4);
            replaceValues.Add('V', 5);
            replaceValues.Add('W', 6);
            replaceValues.Add('X', 7);
            replaceValues.Add('Y', 8);
            replaceValues.Add('Z', 9);
            replaceValues.Add('1', 1);
            replaceValues.Add('2', 2);
            replaceValues.Add('3', 3);
            replaceValues.Add('4', 4);
            replaceValues.Add('5', 5);
            replaceValues.Add('6', 6);
            replaceValues.Add('7', 7);
            replaceValues.Add('8', 8);
            replaceValues.Add('9', 9);
            replaceValues.Add('0', 0);
            //Make sure it is a Valid Year 
            if (!replaceValues.ContainsKey(year) && year != '0')
            {
                return blnIsValid;
            }
            //Make sure characters that are in the VIN are the ones allowed. 
            for (int i = 0; i < p_strVin.Length; i++)
            {
                if (!replaceValues.ContainsKey(p_strVin[i]))
                {
                    return false;
                }
                intValue += (intWeights[i] * ((int)replaceValues[p_strVin[i]]));
            }
            if ((intValue % 11) == intCheckValue)
            {
                blnIsValid = true;
            }
            return blnIsValid;
