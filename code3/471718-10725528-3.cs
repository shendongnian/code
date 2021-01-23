    public static string PlainTextToRtf(string plainText)
    {
      string escapedPlainText = plainText.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
      string rtf = @"{\rtf1\ansi{\fonttbl\f0\fswiss Helvetica;}\f0\pard ";
      rtf += escapedPlainText.Replace(Environment.NewLine, @" \par ");
      rtf += " }";
      return rtf;
    }
