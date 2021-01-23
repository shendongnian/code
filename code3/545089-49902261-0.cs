     //Get Account PrimaryContact details
            public static void GetAccountPrimaryContactDetails(Guid accountId, IOrganizationService orgService)
            {
                var contactFirstName = default(object);
                var contactLastName = default(object);
                var contactFullName = default(object);
                string fetchXML = string.Format(@"<fetch version='1.0' output-format='xml-platform' no-lock='true' mapping='logical'>
                                        <entity name='account'>
                                            <attribute name='name' />                                                                                
                                            <filter type='and'>
                                                <condition attribute='statuscode' operator='eq' value='1' />                                            
                                                <condition attribute='accountid' operator='eq' value='{0}' />
                                            </filter>                                        
                                            <link-entity name='contact' from='contactid' to='primarycontactid' alias='ab'>
                                                 <attribute name='fullname' alias='as_fullname' />
                                                 <attribute name='firstname' alias='as_firstname' />                                             
                                                 <attribute name='lastname' alias='as_lastname' />
                                            </link-entity>
                                        </entity>
                                    </fetch>", accountId.ToString());
                var fetchExp = new FetchExpression(fetchXML);
                EntityCollection accountEntity = orgService.RetrieveMultiple(fetchExp);
                if (accountEntity.Entities.Count > 0)
                {
                    //Primary Contact Fullname
                    AliasedValue avContactFullname = accountEntity.Entities[0].GetAttributeValue<AliasedValue>("as_fullname");
                    if (avContactFullname != null)
                        contactFullName = avContactFullname.Value;
                    //Primary Contact Firstname
                    AliasedValue avContactFirstname = accountEntity.Entities[0].GetAttributeValue<AliasedValue>("as_firstname");
                    if (avContactFirstname != null)
                        contactFirstName = avContactFirstname.Value;
                    //Primary Contact Lastname
                    AliasedValue avContactLastname = accountEntity.Entities[0].GetAttributeValue<AliasedValue>("as_lastname");
                    if (avContactLastname != null)
                        contactLastName = avContactLastname.Value;
