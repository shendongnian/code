    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    public class Enums
    {
        public enum Duration
        { 
            [Display(Name = "1 Hour")]
            OneHour,
            [Display(Name = "1 Day")]
            OneDay
        }
        
        // Helper method to display the name of the enum values.
        public static string GetDisplayName(Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }
    }
