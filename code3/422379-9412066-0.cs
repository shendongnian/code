    var doc = XDocument.Parse(@"<lines>
    <line>public static void main(String[] args)</line>
    <line>{</line>
    <line>   &lt;&gt;double <inline>result</inline> = Math.pow(2, 3);</line>
    <line>   . . .</line>
    <line>    </line> &apos;white space also comes
    <line>}</line>
    </lines>", LoadOptions.PreserveWhitespace);
    string result = doc.Root.Value;
    Console.WriteLine(result);
