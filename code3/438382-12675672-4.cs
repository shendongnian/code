    public static void Main()
    {
        string sqlText = "WHERE DEPT_NAME LIKE '--Test--' AND START_DATE < SYSDATE -- Don't go over today";
        //for every matching line call callback func
        string result = Regex.Replace(sqlText, ".*--.*", RemoveSQLCommentCallback);
    }
