    [MessageContract]
    public class MixedServerandClientSideData
    {
        private ClientSideFilledData clientSideFilledData;
        [MessageBodyMember]
        public ClientSideFilledData ClientSideFilledData
        {
            get { return clientSideFilledData; }
            set { clientSideFilledData = value; }
        }
        private ClientSideFilledData serverSideFilledData;
        [MessageBodyMember]
        public ClientSideFilledData ServerSideFilledData
        {
            get { return serverSideFilledData; }
            set { serverSideFilledData = value; }
        }
    }
