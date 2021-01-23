    unsafe public struct HSNS
    {
        public char *snsAccessID;      
        public char *snsSecretKey;     
        public char *snsPath;          
        public char *snsTopicName;     
        public char *snsTopicAmazonResourceName; 
        public char *snsDisplayName;   
        public char *snsOwnerId;       
    }
    
    [DllImport("Cloud.dll", SetLastError = true)]
    public unsafe static extern Boolean SnsOpenTopic(Byte* accessID, Byte* secretKey, Byte* ownerId, Byte* path, Byte* topicName, Byte* displayName, ref HSNS snsAcsTopic);
    
    // Sample of encoding conversion
    public Byte[] topicName = Encoding.ASCII.GetBytes("CSharpACSAlert\0");
