    strText = "Would \"you\" like to have responses to your \"questions\" sent to you via email?";
    MatchCollection mc = Regex.Matches(strText, "\"([^\"]*)\"");
    for (int z=0; z < mc.Count; z++)
    {
        Response.Write(mc[z].ToString().Replace("\"", ""));
    }
