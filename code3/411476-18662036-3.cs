    private bool ChangeEFConnectionString(string connStringName, string newValue)
    {
        try
        {
            //CreateXDocument and load configuration file
            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            //Find all connection strings
            var query1 = from p in doc.Descendants("connectionStrings").Descendants()
                         select p;
            //Go through each connection string elements find atribute specified by argument and replace its value with newVAlue
            foreach (var child in query1)
            {
                foreach (var atr in child.Attributes())
                {
                    if (atr.Name.LocalName == "name" && atr.Value == connStringName)
                    {
                        if (atr.NextAttribute != null && atr.NextAttribute.Name == "connectionString")
                        {
                            // Create the EF connection string from existing
                            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(atr.NextAttribute.Value);
                            //
                            entityBuilder.ProviderConnectionString = newValue;
                            //back the modified connection string to the configuration file
                            atr.NextAttribute.Value = entityBuilder.ToString();
                        }
                    }
                }
            }
            doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
