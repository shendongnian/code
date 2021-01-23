    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            return Regex.Replace(strIn, @"[^\w\.@-]", ""); 
        }
    }
