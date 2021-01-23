            var automation = LyncClient.GetAutomation();
            var conversationModes = AutomationModalities.Audio;
            var conversationSettings = new Dictionary<AutomationModalitySettings, object>();
            List<string> participants = new List<string>();
            Conversation conv = args.Conversation;            
            string voicemailURI = String.Format("{0};opaque=app:voicemail",conv.SelfParticipant.Contact.Uri);
            participants.Add(voicemailUri);
            automation.BeginStartConversation(AutomationModalities.Audio, participants, null, StartConversationCallback, automation);
