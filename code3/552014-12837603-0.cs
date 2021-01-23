    private static string GetValue(string providerName, string settingName, Func<string, string> getValue)
    {
      string str1 = getValue(settingName);
      string str2;
      if (str1 != null)
        str2 = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "PASS ({0})", new object[1]
        {
          (object) str1
        });
      else
        str2 = "FAIL";
      Trace.WriteLine(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Getting \"{0}\" from {1}: {2}.", (object) settingName, (object) providerName, (object) str2));
      return str1;
    }
