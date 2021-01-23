    using System.Linq;
    // Assuming constants are strings
    IList<string> constants = new List<string> 
               {
                  Constants.PREF_PricingTypesFormWidth,
                  Constants.PREF_PricingTypesFormTop,
               };
    bool DoneFlag = constants.Any(p => p == perf_const);
