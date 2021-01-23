    using System.ComponentModel.DataAnnotations;
    public enum Duration 
    { 
        [Description("Eight hours")]
        Day,
    
        [Description("Five days")]
        Week,
    
        [Description("Twenty-one days")] 
        Month 
    }
