    public List<string> net_adapters()
    {
         List<string> values = new List<string>();
         foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
         {
             values.Add(nic.Name);
         }
         return values;
    }
    
