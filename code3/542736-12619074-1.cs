    namespace Build_Server_Lync_Notifier
    {
        class LyncManager
        {
            private string _uri;
            private string _message;
            private LyncClient _client;
            private Conversation _conversation;
            private bool _done = false;
            public bool Done
            {
                get { return _done; }
            }
            public LyncManager(string arg0, string arg1)
            {
                _uri = arg0;
                _message = arg1;
                _client = Microsoft.Lync.Model.LyncClient.GetClient();
                _client.ContactManager.BeginSearch(
                    _uri,
                    SearchProviders.GlobalAddressList,
                    SearchFields.EmailAddresses,
                    SearchOptions.ContactsOnly,
                    2,
                    BeginSearchCallback,
                    new object[] { _client.ContactManager, _uri }
                );
            }
            private void BeginSearchCallback(IAsyncResult r)
            {
                object[] asyncState = (object[]) r.AsyncState;
                ContactManager cm = (ContactManager) asyncState[0];
                try
                {
                    SearchResults results = cm.EndSearch(r);
                    if (results.AllResults.Count == 0)
                    {
                        Console.WriteLine("No results.");
                    }
                    else if (results.AllResults.Count == 1)
                    {
                        ContactSubscription srs = cm.CreateSubscription();
                        Contact contact = results.Contacts[0];
                        srs.AddContact(contact);
                        ContactInformationType[] contactInformationTypes = { ContactInformationType.Availability, ContactInformationType.ActivityId };
                        srs.Subscribe(ContactSubscriptionRefreshRate.High, contactInformationTypes);
                        _conversation = _client.ConversationManager.AddConversation();
                        _conversation.AddParticipant(contact);
                        Dictionary<InstantMessageContentType, String> messages = new Dictionary<InstantMessageContentType, String>();
                        messages.Add(InstantMessageContentType.PlainText, _message);
                        InstantMessageModality m = (InstantMessageModality)_conversation.Modalities[ModalityTypes.InstantMessage];
                        m.BeginSendMessage(messages, BeginSendMessageCallback, messages);
                    }
                    else
                    {
                        Console.WriteLine("More than one result.");
                    }
                }
                catch (SearchException se)
                {
                    Console.WriteLine("Search failed: " + se.Reason.ToString());
                }
                _client.ContactManager.EndSearch(r);
            }
            private void BeginSendMessageCallback(IAsyncResult r)
            {
                _conversation.End();
                _done = true;
            }
        }
    }
