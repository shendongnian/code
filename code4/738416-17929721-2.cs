    [DllImport("Cloud.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern Boolean SnsOpenTopic(string accessID, string secretKey, string ownerId, string path, string topicName, string displayName, ref HSNS snsTopicHandle);
    [StructLayout(LayoutKind.Sequential)]
    public struct HSNS
    {
        public IntPtr snsAccessID;      
        public IntPtr snsSecretKey;     
        public IntPtr snsPath;          
        public IntPtr snsTopicName;     
        public IntPtr snsTopicAmazonResourceName; 
        public IntPtr snsDisplayName;   
        public IntPtr snsOwnerId;       
    }
