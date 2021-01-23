        public void Update(RelayConfig relayConfig, List<StandardContact> exposedContacts) {
            RelayConfig dbRelayConfig = context.RelayConfigs.Include(r => r.StandardContacts)
                                               .Where(r => r.Id == relayConfig.Id).SingleOrDefault();
            context.Entry<RelayConfig> (dbRelayConfig).CurrentValues.SetValues(relayConfig);
            List<StandardContact> addedExposedContacts = 
                exposedContacts.Where(c1 => !dbRelayConfig.StandardContacts.Any(c2 => c1.Id == c2.Id)).ToList();
            List<StandardContact> deletedExposedContacts = 
                dbRelayConfig.StandardContacts.Where(c1 => !exposedContacts.Any(c2 => c2.Id == c1.Id)).ToList();
            StandardContact dbExposedContact = null;
            addedExposedContacts.ForEach(exposedContact => {
                dbExposedContact = context.StandardContacts.SingleOrDefault(sc => sc.Id == exposedContact.Id);
                dbRelayConfig.StandardContacts.Add(dbExposedContact);
            });
            deletedExposedContacts.ForEach(exposedContact => { dbRelayConfig.StandardContacts.Remove(exposedContact);});
