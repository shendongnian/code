    class MessageConventions : IWantToRunBeforeConfiguration { 
       public void Init() {
          Configure.Instance.DefiningMessagesAs(t => t.Namespace != null &&  
                t.Namespace.StartsWith("Your.Messages.Namespace.Here"));
       }
    }
