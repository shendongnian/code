       public enum GasKeyWords
       {
           [Description("Gas")] 
           Gas,
           [Description("Fuel")]
           Fuel,
           [Description("Gas&Fuel")]
           GasFuel
       }
       ...
 
       var gasKeywords = Util.GetDescriptions<GasKeywords>();
       foreach(var r in records)
       {
            var found = gasKeywords.Contains(r);
            if (found)
            {
            }
       }
