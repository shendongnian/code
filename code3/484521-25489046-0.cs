    public static string RemoveQueryStringByKey(string sURL, string sKey)
        {
            string sOutput = string.Empty;
            string sToReplace = string.Empty;
            int iFindTheKey = sURL.IndexOf(sKey);
            if (iFindTheKey == -1) return (sURL);
            int iQuestion = sURL.IndexOf('?');
            if (iQuestion == -1) return (sURL);
            string sEverythingBehindQ = sURL.Substring(iQuestion);
            List<string> everythingBehindQ = new List<string>(sEverythingBehindQ.Split('&'));
            foreach (string OneParamPair in everythingBehindQ)
            {
                int iIsKeyInThisParamPair = OneParamPair.IndexOf(sKey);
                if (iIsKeyInThisParamPair != -1)
                {
                    sToReplace = "&" + OneParamPair;
                }
            }
            sOutput = sURL.Replace(sToReplace, "");
            return (sOutput);
        }
