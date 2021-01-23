    public string GetApplicationVersion()
    {
      var ver = Windows.ApplicationModel.Package.Current.Id.Version;
      return ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString() + "." + ver.Revision.ToString();
    }
