    public bool IsMailEnabled
            {
                get
                {
                    var proxyAddresses = ExtensionGet("proxyAddresses");
                    if (proxyAddresses == null)
                        return false;
    
                    if (proxyAddresses.Length == 0)
                        return false;
    
                    try
                    {
                        List<string> proxyAddressesStringList = proxyAddresses.Cast<string>().ToList();
                        if (proxyAddressesStringList.Where(x => x.StartsWith("smtp:", StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                            return true;
                        else
                            return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
