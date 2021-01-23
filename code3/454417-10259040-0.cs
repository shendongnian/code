    public static IEnumerable<string> SeverityOrHigher(string severity)
    {
      var lastFound = -1;
      var severityList = new List<string>() { "ALL", "DEBUG", "INFO", "WARN", "ERROR", "FATAL", "OFF" };
      var results = new List<string>();
      foreach (var t in severityList)
      {
        if (lastFound > -1)
        {
          for (var index = lastFound + 1; index < severityList.Count; index++)
          {
            results.Add(severityList[index]);
          }
          return results;
        }
        switch (severity.ToUpper())
        {
          case "ALL":
            results.Add(severity);
            lastFound = 0;
            break;
          case "DEBUG":
            lastFound = 1;
            results.Add(severity);
            break;
          case "INFO":
            lastFound = 2;
            results.Add(severity);
            break;
          case "WARN":
            lastFound = 3;
            results.Add(severity);
            break;
          case "ERROR":
            lastFound = 4;
            results.Add(severity);
            break;
          case "FATAL":
            lastFound = 5;
            results.Add(severity);
            break;
          case "OFF":
            lastFound = 6;
            results.Add(severity);
            break;
        }
      }
      return results;
    }
