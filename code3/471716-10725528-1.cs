    public static string PlainTextToRtf(string plainText)
    {
      string rtf = @"{\rtf1\ansi{\fonttbl\f0\fswiss Helvetica;}\f0\pard ";
      rtf += plainText.Replace(Environment.NewLine, @" \par ");
      rtf += " }";
      return rtf;
    }
