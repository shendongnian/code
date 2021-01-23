    public static string RemoveJsonNulls(this string str)
        {
            if (!str.IsEmptyOrNull())
            {
                Regex regex = new Regex(UtilityRegExp.JsonNullRegEx);
                string data = regex.Replace(str, string.Empty);
                regex = new Regex(UtilityRegExp.JsonNullArrayRegEx);
                return regex.Replace(data, "[]");
            }
            return null;
        }
    public static string JsonNullRegEx = "[\"][a-zA-Z0-9_]*[\"]:null[ ]*[,]?";
    public static string JsonNullArrayRegEx = "\\[( *null *,? *)*]";
