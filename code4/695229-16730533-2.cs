    using TransportInterface;
    
    // ...
    
    private void LoadTransportPlugins()
    {
        string folder = System.AppDomain.CurrentDomain.BaseDirectory + "\\Transports";
    
        string[] files = Directory.GetFiles(folder, "*.dll");
    
        foreach (string file in files)
            try
            {
                Assembly assembly = Assembly.LoadFile(file);
    
                foreach (Type type in assembly.GetTypes())
                {
                    Type iface = type.GetInterface("TransportInterface.Transport");
    
                    if (iface != null)
                    {
                        try
                        {
                            Transport plugin = (Transport)Activator.CreateInstance(type);
    
                            // executing this code means transport creation succeded
                        }
                        catch (Exception ex)
                        {
                            _System(ex.InnerException.Message + '\n', Color.Red);
                        }
                        AnyPlugins = true;
                    }
                }
            }
            catch { };
    }
