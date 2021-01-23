    static class DateHandler 
    {     
        #region Properties      
        private static Date Date;
        private static Dictionary<char, string> properties;
        private static Dictionary<char, string> Properties 
        {
            get
            {
                if (properties == null)
                {
                    properties = new Dictionary<char, string>();
                    SetProperties();
                }
                return properties;
            }
            set
            {
                properties = value;
            }
        }
        private static int Properties_Count;      
        #endregion      
  
        #region Methods      
        
        private static void SetProperties()     
        {         
            Properties.Add('d', Date.Day + "");         
            Properties.Add('m', Date.Month + "");         
            Properties.Add('Y', Date.Year + "");         
            Properties.Add('y', Date.Year.ToString().Substring(Math.Max(0, Date.Year.ToString().Length - 2)));         
            Properties_Count = Properties.Count;     
        }
        public static string Format(Date date, string FormatString)     
        {
            Date = date;
            int len = FormatString.Length;         
            if (Properties.ContainsKey(FormatString[0]))         
            {             
                FormatString = FormatString.Replace(FormatString[0] + "", Properties[FormatString[0]] + "");         
            }         
            for (int i = 1; i < len; i++)         
            {             
                if (Properties.ContainsKey(FormatString[i]) && FormatString[i - 1] != '\\')             
                {                 
                    FormatString = FormatString.Replace(FormatString[i] + "", Properties[FormatString[i]] + "");             
                }         
            }         
            return FormatString;     
        }      
        #endregion 
    } 
