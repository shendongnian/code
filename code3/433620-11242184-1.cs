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
                    Regex.Replace(tmpBarcode, strRegExMatch,""); //remove the AI and its value so that its value can't be confused as another AI
                    arrAIs[arrayIndex] = new string[] { strAI, Regex.Split(strRegExMatch, strAI)[1] };
                }
