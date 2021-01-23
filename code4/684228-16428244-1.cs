                // this is the case, when client and its settings are new entities
                var client = new Client { Name = "Jonh" };
                // note, that in this case you should initialize navigation property
                var clientSettings = new ClientSettings { Client = client, SomeSetting = true };
                context.ClientSettings.Add(clientSettings);
                context.SaveChanges();
                // this is the case, when client already exists in database, and settings are new entity
                var client2 = new Client { Name = "Mary" };
                context.Clients.Add(client2);
                context.SaveChanges();
                // in this case you can initialize either navigation property, or foreign key property
                var clientSettings2 = new ClientSettings { SettingsId = client2.Id, SomeSetting = true };
                context.ClientSettings.Add(clientSettings2);
                context.SaveChanges();
