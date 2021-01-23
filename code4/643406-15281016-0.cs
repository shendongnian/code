    public class OPCCaException : Exception
    {
        ReturnCode returnCode;
        string serverName;
        string nodeName;
        public OPCCaException(ReturnCode returnCode, string serverName, string nodeName)
            : base();
        {
             this.returnCode = returnCode;
             this.serverName = serverName;
             this.nodeName = nodeName;
        }
        public override string Message
        {
            get
            {
                 return string.Format("Failed to connect to OPC server {0}{1}: {2}",
                     serverName, 
                     string.IsNullOrEmpty(nodeName ? "" : " on node " + nodeName),
                     TranslateReturnCode(returnCode)
                 );
            }
        }
    }
