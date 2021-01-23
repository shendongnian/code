      try {
        if (ApplicationDeployment.CurrentDeployment == null ||
          ApplicationDeployment.CurrentDeployment.ActivationUri == null)
          return null;
      } catch {
        // application was not activated from the web
        return null;
      }
      Uri uri = ApplicationDeployment.CurrentDeployment.ActivationUri;
      string query = uri.Query;
      if (string.IsNullOrEmpty(uri.Query))
        throw new UIException("Activation Uri is empty.");
      Regex regex;
      Match match;
      regex = new Regex(@".*ConnectionString=(?<ConnectionString>([A-Z0-9\+/=:%\._-]+))", RegexOptions.IgnoreCase);
      match = regex.Match(uri.Query);
      if (match == null || !match.Success) {
        throw new UIException("ConnectionString not recognized as part of activation Uri.");
      }
      return HttpUtility.UrlDecode(match.Groups["ConnectionString"].Value);
