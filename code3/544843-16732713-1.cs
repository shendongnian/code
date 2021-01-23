        public static void CreateCoCPITAppPool(string strName)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                ApplicationPool newPool = serverManager.ApplicationPools.Add(strName);
                newPool.ManagedRuntimeVersion = "v4.0";
                newPool.AutoStart = true;
                newPool.ProcessModel.UserName = "username";
                newPool.ProcessModel.Password = "password";
                newPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
                newPool.Recycling.PeriodicRestart.Time = TimeSpan.Zero;
                newPool.ProcessModel.IdleTimeout = TimeSpan.FromMinutes(10000); // .Zero;
                newPool.ProcessModel.ShutdownTimeLimit = TimeSpan.FromSeconds(3600);
                newPool.Failure.RapidFailProtection = false;
                serverManager.CommitChanges();
                IDictionary<string, string> attr = newPool.Recycling.RawAttributes;
                foreach (KeyValuePair<String, String> entry in attr)
                {
                    // do something with entry.Value or entry.Key
                    Console.WriteLine(entry.Key + " = " + entry.Value);
                }
                ConfigurationAttributeCollection coll = newPool.Recycling.Attributes;
                foreach (ConfigurationAttribute x in coll)
                {
                    Console.WriteLine(x.Name + " = " + x.Value);
                }
            }
        }
