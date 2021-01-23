    strAI = arrAI[0];
                intMin = int.Parse(arrAI[2]);
                intMax = int.Parse(arrAI[3]);
                strType = arrAI[4];
    strRegExMatch = "";
                if (strType == "alphanumeric")
                {
                    strRegExMatch = Regex.Match(tmpBarcode, strAI + @"\w{" + intMin + "," + intMax + "}").ToString();
                }
                else
                {
                    strRegExMatch = Regex.Match(tmpBarcode, strAI + @"\d{" + intMin + "," + intMax + "}").ToString();
                }
                if (strRegExMatch.Length > 0)
                {
                    tmpBarcode = Regex.Replace(tmpBarcode, strRegExMatch, ""); //remove the AI and its value so that its value can't be confused as another AI
                    strRegExMatch = Regex.Replace(strRegExMatch, strAI, ""); //remove the AI from the match
                    arrAIs[arrayIndex] = new string[] { strAI, strRegExMatch };
                }
                arrayIndex++;
