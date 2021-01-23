    using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["yourConnection"].ConnectionString))
            {
                return db.Query<dynamic, DeviceA, DeviceA, Device>(@"
                    Select
                        Discriminator,
                        ...
                    From Device", (d, da, db) =>
                    {
                        if (p.Discriminator == "DeviceA")
                        {
                            return new DeviceA();
                        }
                        else if (p.Discriminator == "DeviceB")
                        {
                             return new DeviceB();
                        }
                        return d;
                    });       
                    
