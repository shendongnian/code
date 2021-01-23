        public ChatMessage()
        {   
            MessageID = ApplicationState.GetNextChatMessageID(); // An expensive call that uses up an otherwise free ID from a limited set and does disk access in the process.
        }
        [JsonConstructor] // This forces JsonSerializer to call it instead of the default.
        [Obsolete("Call the default constructor. This is only for JSONserializer", true)] // To make sure that calling this from your code directly will generate a compiler error. JSONserializer can still call it because it does it via reflection.
        public ChatMessage(bool DO_NOT_CALL_THIS)
        {
        }
