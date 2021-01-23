{<br/>
    string inStr = "ó";<br/>
    string auxStr = System.Net.WebUtility.HtmlEncode(inStr);<br/>
    // auxStr == &\#243;<br/>
    string outStr = System.Net.WebUtility.HtmlDecode(auxStr);<br/>
    // outStr == <b>&\#243;</b><br/>
    string outStr2 = System.Net.WebUtility.HtmlDecode("&\oacute;");<br/>
    // outStr2 == <b>ó</b><br/>
}<br/>
