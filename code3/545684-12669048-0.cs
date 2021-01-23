     public class DispatchByBodyElementOperationSelector : IDispatchOperationSelector
        {
            #region fields
    
            private const string c_default = "default";
            readonly Dictionary<string, string> m_dispatchDictionary;
    
            #endregion
    
            #region constructor
    
            public DispatchByBodyElementOperationSelector(Dictionary<string, string> dispatchDictionary)
            {
                m_dispatchDictionary = dispatchDictionary;
                Debug.Assert(dispatchDictionary.ContainsKey(c_default), "dispatcher dictionary must contain a default value");
            }
    
            #endregion
    
            public string SelectOperation(ref Message message)
            {
                string operationName = null;
                var bodyReader = message.GetReaderAtBodyContents();
                var lookupQName = new
                   XmlQualifiedName(bodyReader.LocalName, bodyReader.NamespaceURI);
    
                // Since when accessing the message body the messageis marked as "read"
                // the operation selector creates a copy of the incoming message 
                message = CommunicationUtilities.CreateMessageCopy(message, bodyReader);
    
                if (m_dispatchDictionary.TryGetValue(lookupQName.Name, out operationName))
                {
                    return operationName;
                }
                return m_dispatchDictionary[c_default];
            }
        }
