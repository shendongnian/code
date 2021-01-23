       protected void Page_Load(object sender, EventArgs e)
        { 
            SendLyncMessage();
        }
       private static void SendLyncMessage()
        {
            string[] targetContactUris = {"sip:xxxx@domain.com"};
            LyncClient client = LyncClient.GetClient();
            Conversation conv = client.ConversationManager.AddConversation();
           
            foreach (string target in targetContactUris)
            {
                conv.AddParticipant(client.ContactManager.GetContactByUri(target));
            }
            InstantMessageModality m = conv.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
            m.BeginSendMessage("Test Message", null, null);
        }
