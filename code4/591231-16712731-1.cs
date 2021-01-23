         public static string WildcardFormatSpecialCharacter(string source)
        {
            string formattedResult = string.Empty;
            if (!String.IsNullOrEmpty(source))
            {
                //Escape the escape character
                formattedResult = source.Replace(DataLayerConstants.EscapeCharacter, DataLayerConstants.EscapeCharacterWithEscape);
                //The %
                formattedResult = formattedResult.Replace(DataLayerConstants.Percentage, DataLayerConstants.PercentageWithEscape);
                //The [
                formattedResult = formattedResult.Replace(DataLayerConstants.OpenSqaureBracket, DataLayerConstants.OpenSqaureBracketWithEscape);
                //The ]
                formattedResult = formattedResult.Replace(DataLayerConstants.CloseSqaureBracket, DataLayerConstants.CloseSqaureBracketWithEscape);
                //The _
                formattedResult = formattedResult.Replace(DataLayerConstants.Underscore, DataLayerConstants.UnderscoreWithEscape);
            }
            return formattedResult;
        }
 
 
        public const string EscapeCharacter = @"\";
        public const string EscapeCharacterWithEscape = @"\\";
        public const string Percentage = "%";
        public const string PercentageWithEscape = @"\%";
        public const string OpenSqaureBracket = "[";
        public const string OpenSqaureBracketWithEscape = @"\[";
        public const string CloseSqaureBracket = "]";
        public const string CloseSqaureBracketWithEscape = @"\]";
        public const string Underscore = "_";
        public const string UnderscoreWithEscape = @"\_";
