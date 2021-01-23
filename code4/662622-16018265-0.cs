    static void Main(string[] args)
    {
        ExchangeServiceBinding esb = new ExchangeServiceBinding();
        esb.Url = @"https://myserver/EWS/Exchange.asmx";
        esb.Credentials = new NetworkCredential(
                              "username",
                              @"password",
                              @"domain");
 
        // Create the ResolveNamesType and set
        // the unresolved entry.
        ResolveNamesType rnType = new ResolveNamesType();
        rnType.ReturnFullContactData = true;
        rnType.UnresolvedEntry = "test";
 
        // Resolve names.
        ResolveNamesResponseType resolveNamesResponse = esb.ResolveNames(rnType);
        ArrayOfResponseMessagesType responses = resolveNamesResponse.ResponseMessages;
 
        // Check the result.
        if (responses.Items.Length > 0 && responses.Items[0].ResponseClass != ResponseClassType.Error)
        {
            ResolveNamesResponseMessageType responseMessage = responses.Items[0] as ResolveNamesResponseMessageType;
                 
            // Display the resolution information.
            ResolutionType[] resolutions =
            responseMessage.ResolutionSet.Resolution;
            
            foreach (ResolutionType resolution in resolutions)
            {
                Console.WriteLine("Name: " + resolution.Contact.DisplayName);
                Console.WriteLine("EmailAddress: " + resolution.Mailbox.EmailAddress);
 
                if (resolution.Contact.PhoneNumbers != null)
                {
                    foreach (PhoneNumberDictionaryEntryType phone in resolution.Contact.PhoneNumbers)
                    {
                        Console.WriteLine(phone.Key.ToString() + " : " + phone.Value);
                    }
                }
                Console.WriteLine("Office location:" + resolution.Contact.OfficeLocation);
                Console.WriteLine("\n");
            }
        }
    }
