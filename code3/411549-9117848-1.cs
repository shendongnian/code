    // you're not using the elements, ignore them, just get the attributes
    foreach (var atr in xelt.Descendants()
                            .SelectMany(e => e.Attributes())
                            .Where(a => a.Value.Length >= 13
                                     && a.Value.Length <= 16))
    {
        // static basicDigits = new Regex(@"\b\d+\b", RegexOptions.Compiled);
        // static ccDigits = new Regex(@"\b\d{13,16}\b", RegexOptions.Compiled);
        if (ccDigits.IsMatch(atr.Value))
        {
             atr.Value = ccDigits.Replace(
                 atr.Value,
                 mm => new String('*', mm.Value.Length - 4)
                       + mm.Value.Substring(mm.Value.Length - 4));
        }
        else
        {
            atr.Value = basicDigits.Replace(atr.Value, "***");
        }
    }
    // using 300k XML (3k nodes/10k attrs, 3 attr/node avg, avg depth 4 nodes)
    // with 10% match rate:
    // - 40.5 MB/s (average 100 trials)
    // - 96 attributes/ms
