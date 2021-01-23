       public void Input(string Data)
        {
            if (Output != null)
            {
                Prefix = ApplyReplaceRules(Prefix);
    
                Postfix = ApplyReplaceRules(Postfix);
    
                Output((int) OutputsEnum.OutputBeforeModified, Data);
                Output((int) OutputsEnum.OutputModified, Prefix + Data + Postfix);
                Output((int) OutputsEnum.OutputAfterModified, Data);
            }
        }
    
        private string ApplyReplaceRules(string patternString)
        {
            if (!String.IsNullOrEmpty(Postfix))
            {
                patternString = patternString.Replace("{DS1}", DataStoreContents[0]);
                patternString = patternString.Replace("{DS2}", DataStoreContents[1]);
                patternString = patternString.Replace("{DS3}", DataStoreContents[2]);
                patternString = patternString.Replace("{DS4}", DataStoreContents[3]);
            }
           
            return patternString;
        }
