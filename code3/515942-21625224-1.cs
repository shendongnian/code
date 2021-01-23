    private const int c_ulConvIndexIDOffset = 6;
    private const int c_ulConvIndexIDLength = 16;
    private string GetConversationId()
            {
                var convTracking = GetMapiPropertyBool(PR_CONVERSATION_INDEX_TRACKING);
                var convIndex = GetMapiPropertyBytes(PR_CONVERSATION_INDEX);
                byte[] idBytes;
                if (convTracking
                    && convIndex != null
                    && convIndex.Length > 0)
                {
                    // get Id from Conversation index
                    idBytes = new byte[c_ulConvIndexIDLength];
                    Array.Copy(convIndex, c_ulConvIndexIDOffset, idBytes, 0, c_ulConvIndexIDLength);
                }
                else
                {
                    // get Id from Conversation topic
                    var topic = GetMapiPropertyString(PR_CONVERSATION_TOPIC);
                    if (string.IsNullOrEmpty(topic))
                    {
                        return string.Empty;
                    }
                    if (topic.Length >= 265)
                    {
                        topic = topic.Substring(0, 256);
                    }
                    topic = topic.ToUpper();
                    using (var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                    {
                        idBytes = md5.ComputeHash(Encoding.Unicode.GetBytes(topic));
                    }
                }
                return BitConverter.ToString(idBytes).Replace("-", string.Empty);
            }
