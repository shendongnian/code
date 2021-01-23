    switch (severity.ToUpper())
    {
      case "ALL":
        result.Add("ALL");
        goto case "DEBUG";
      case "DEBUG":
        result.Add("DEBUG");
        goto case "INFO";
      case "INFO":
        result.Add("INFO");
        goto case "WARN";
      case "WARN":
        result.Add("WARN");
        goto case "ERROR";
      case "ERROR":
        result.Add("ERROR");
        goto case "FATAL";
      case "FATAL":
        result.Add("FATAL");
        goto case "OFF";
      case "OFF":
        result.Add("OFF");
        break;
      default:
        break;
    }
