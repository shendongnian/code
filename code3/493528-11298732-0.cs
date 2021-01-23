    private static void HtmlDecodeTest()
    {
        string html = @"
    &lt;POSTBACK&gt;
        &lt;NOTIFICATION id=""4254"" created=""2012-07-02 13:35:46.629214-04""&gt;
        &lt;ORIGIN&gt;SMS_MO&lt;/ORIGIN&gt;
        &lt;CODE&gt;N211&lt;/CODE&gt;
        &lt;BODY&gt;&lt;FROM&gt;+15035555555&lt;/FROM&gt;&lt;TO&gt;60856&lt;/TO&gt;&lt;TEXT&gt;cats are cats&lt;/TEXT&gt;&lt;RECEIVED&gt;2012-07-02 13:35:46.038477-04&lt;/RECEIVED&gt;&lt;/BODY&gt;
        &lt;/NOTIFICATION&gt;
    &lt;/POSTBACK&gt;";
    
        string x = HttpUtility.HtmlDecode(html);
        Console.WriteLine(x);
    }
