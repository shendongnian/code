    namespace System
    {    
        public static class Extensions
        {
            public static string w(this string message)
            {
                return VCBox.Helpers.Localization.w(message);  
            }
        }
    }
