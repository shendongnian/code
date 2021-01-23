        public void CreateNewContactWithOptionListValue(string lastName, string theOptionListValue)
        {
            using (var context = new CrmOrganizationServiceContext(new CrmConnection("Xrm")))
            {
                new_customoptionset parsedValue;
                if (!Enum.TryParse<new_customoptionset>(theOptionListValue, out parsedValue))
                {
                    throw new InvalidPluginExecutionException("Unknown value");
                }
                var contact = new Contact()
                {
                    LastName = lastName,
                    OptionListValue = new OptionSetValue((int)parsedValue)
                };
                context.Create(contact);
            }
        }
