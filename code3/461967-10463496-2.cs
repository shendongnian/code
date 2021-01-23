            String source1 = "02/02/12-02:45 PM(CKI)-DISC RSPNS SRVD 01/31/12-PRINTED
     DISCOVERY:spina.bp.doc(DGB) 01/27/12-ON CAL-FILED NOTICE OF TRIAL(JCX) 01/24/12-SENT
     OUR DEMANDS(Auto-Gen) 01/23/12- 02:31 PM-File pulled and given to KG for responses.(JLS) 01/20/12(PC)-rcd df jmt af ";
        String assembledString;
        public void bumbleBeeTunaTest()
        {
            String strippedString = source1.Replace(" ", "");
            String regString1 = ""; 
            String regString2 = @"([A-Z]{6,})";
            String matchHold1,matchHold1First,matchHold1Last,matchHold1Middle;
            Int32 matchHold1Len;
            Regex regExTwo = new Regex(regString2);
            MatchCollection regMatch2 = regExTwo.Matches(strippedString);
            foreach (Match match2 in regMatch2)
            {
                matchHold1 = match2.Groups[1].Value;
                matchHold1Len = matchHold1.Length;
                matchHold1First = matchHold1.Substring(0,1);
                matchHold1Last = matchHold1.Substring(matchHold1Len - 1,1);
                matchHold1Middle = matchHold1.Substring(1, matchHold1Len - 2);
                Debug.Print("Stripped String Matches - " + matchHold1);
                               
                regString1 = @"(" + matchHold1First + "[" + matchHold1Middle+  " ]{" + (matchHold1Len -1) + ",}" + matchHold1Last + ")";
                Regex regExOne = new Regex(regString1);
                MatchCollection regMatch1 = regExOne.Matches(source1);
                regMatch1 = regExOne.Matches(source1);
                foreach (Match match1 in regMatch1)
                {
                   
                    Debug.Print("Re-Assembled Matches :" + match1.Groups[1].Value.ToString());
                }
            }
            // Does the same thing as the above.  Just a little simpler.
            for (int i = 0; i < source1.Length; i++)
            {
                if (char.IsUpper(source1[i]) | char.IsWhiteSpace(source1[i]))
                {
                    assembledString += source1[i];
                }
                else
                {
                    if (!string.IsNullOrEmpty(assembledString))
                    {
                        if (assembledString.Count(char.IsUpper) > 5)
                        {
                            Debug.Print("Non Reg Ex Version "  + assembledString);
                        }
                        assembledString = "";
                    }
                }
            }
        }
