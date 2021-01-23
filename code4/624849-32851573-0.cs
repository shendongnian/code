    public static bool InterfaceHasIpv6Enabled(NetworkInterface @interface)
    {
      try
      {
        var properties = @interface.GetIPProperties().GetIPv6Properties();
        return properties.Index > -999;
      }
      catch (System.Net.NetworkInformation.NetworkInformationException)
      {
        return false;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
