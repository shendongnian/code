    public static string RemoveSQLCommentCallback(System.Text.RegularExpressions.Match SQLLineMatch)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        bool open = false; //opening of SQL String found
        char prev_ch = ' ';
        foreach (char ch in SQLLineMatch.ToString())
        {
            if (ch == '\'')
            {
                open = !open;
            }
            else if ((!open && prev_ch == '-' && ch == '-'))
            {
                break;
            }
            sb.Append(ch);
            prev_ch = ch;
        }
        return sb.ToString().Trim('-');
    }
    public static void Main()
    {
        string sqlText = "WHERE DEPT_NAME LIKE '--Test--' AND START_DATE < SYSDATE -- Don't go over today";
        dynamic result = System.Text.RegularExpressions.Regex.Replace(sqlText, ".*--.*", RemoveSQLCommentCallback); //for every match call callback func
    }
