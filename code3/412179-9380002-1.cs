    string s; //store html content in this variable.
    int i = Microsoft.VisualBasic.Strings.InStr(1, s.ToLower(), "http://");
    int j1 = Microsoft.VisualBasic.Strings.InStr(i+1,s.ToLower(),"\""); 
    int j2 = Microsoft.VisualBasic.Strings.InStr(i+1,s.ToLower(),"'");
    int j;
    if ((j1 < j2) && (j1 > i))
        j = j1;
    else
        j = j2;
    s = Microsoft.VisualBasic.Strings.Mid(s,1,i-1) + "http://www.go.go/default.aspx?url=" + Server.UrlEncode(Microsoft.VisualBasic.Strings.Mid(s,i,j-i)) + Microsoft.VisualBasic.Strings.Mid(s,j);
