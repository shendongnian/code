    public delegate void NewPeerCallback(P2PPeer newPeer);
    public event NewPeerCallback OnNewPeerConnection;
        
    public Pubnub pubnub;
    public string pubnubChannelName;
    public string localIp;
    public string externalIp;
    public int localPort;
    public int externalPort;
    public UdpClient udpClient;
    HashSet<string> uniqueIdsPubNubSeen;
    object peerLock = new object();
    Dictionary<string, P2PPeer> connectedPeers;
    string myPeerDataString;
    public void InitPubnub(string pubnubPublishKey, string pubnubSubscribeKey, string pubnubChannelName)
    {
        uniqueIdsPubNubSeen = new HashSet<string>();
        connectedPeers = new Dictionary<string, P2PPeer>;
        pubnub = new Pubnub(pubnubPublishKey, pubnubSubscribeKey);
        myPeerDataString = localIp + " " + externalIp + " " + localPort + " " + externalPort + " " + pubnub.SessionUUID;
        this.pubnubChannelName = pubnubChannelName;
        pubnub.Subscribe<string>(
            pubnubChannelName,
            OnPubNubMessage,
            OnPubNubConnect,
            OnPubNubError);
        return pubnub;
    }
        
    //// Subscribe callbacks
    void OnPubNubConnect(string res)
    {
        pubnub.Publish<string>(pubnubChannelName, connectionDataString, OnPubNubTheyGotMessage, OnPubNubMessageFailed);
    }
    
    void OnPubNubError(PubnubClientError clientError)
    {
        throw new Exception("PubNub error on subscribe: " + clientError.Message);
    }
    
    void OnPubNubMessage(string message)
    {
        // The message will be the string ["localIp externalIp localPort externalPort","messageId","channelName"]
        string[] splitMessage = message.Trim().Substring(1, message.Length - 2).Split(new char[] { ',' });
        string peerDataString = splitMessage[0].Trim().Substring(1, splitMessage[0].Trim().Length - 2);
        
        // If you want these, I don't need them
        //string peerMessageId = splitMessage[1].Trim().Substring(1, splitMessage[1].Trim().Length - 2);
        //string channelName = splitMessage[2].Trim().Substring(1, splitMessage[2].Trim().Length - 2);
        string[] pieces = peerDataString.Split(new char[] { ' ', '\t' });
        string peerLocalIp = pieces[0].Trim();
        string peerExternalIp = pieces[1].Trim();
        string peerLocalPort = int.Parse(pieces[2].Trim());
        string peerExternalPort = int.Parse(pieces[3].Trim());
        string peerPubnubUniqueId = pieces[4].Trim();
        
        pubNubUniqueId = pieces[4].Trim();
        // If you are on the same device then you have to do this for it to work idk why
        if (peerLocalIp == localIp && peerExternalIp == externalIp)
        {
            peerLocalIp = "127.0.0.1";
        }
        // From me, ignore
        if (peerPubnubUniqueId == pubnub.SessionUUID)
        {
            return;
        }
        // We haven't set up our connection yet, what are we doing
        if (udpClient == null)
        {
            return;
        }
        
        // From someone else
        
        IPEndPoint peerEndPoint = new IPEndPoint(IPAddress.Parse(peerExternalIp), peerExternalPort);
        IPEndPoint peerEndPointLocal = new IPEndPoint(IPAddress.Parse(peerLocalIp), peerLocalPort);
        // First time we have heard from them
        if (!uniqueIdsPubNubSeen.Contains(peerPubnubUniqueId))
        {
            uniqueIdsPubNubSeen.Add(peerPubnubUniqueId);
            
            // Dummy messages to do UDP hole punching, these may or may not go through and that is fine
            udpClient.Send(new byte[10], 10, peerEndPoint);
            udpClient.Send(new byte[10], 10, peerEndPointLocal); // This is if they are on a LAN, we will try both
            pubnub.Publish<string>(pubnubChannelName, myPeerDataString, OnPubNubTheyGotMessage, OnPubNubMessageFailed);
        }
        // Second time we have heard from them, after then we don't care because we are connected
        else if (!connectedPeers.ContainsKey(peerPubnubUniqueId))
        {
            //bool isOnLan = IsOnLan(IPAddress.Parse(peerExternalIp)); TODO, this would be nice to test for
            bool isOnLan = false; // For now we will just do things for both
            P2PPeer peer = new P2PPeer(peerLocalIp, peerExternalIp, peerLocalPort, peerExternalPort, this, isOnLan);
            lock (peerLock)
            {
                connectedPeers.Add(peerPubnubUniqueId, peer);
            }
            
            // More dummy messages because why not
            udpClient.Send(new byte[10], 10, peerEndPoint);
            udpClient.Send(new byte[10], 10, peerEndPointLocal);
            pubnub.Publish<string>(pubnubChannelName, connectionDataString, OnPubNubTheyGotMessage, OnPubNubMessageFailed);
            if (OnNewPeerConnection != null)
            {
                OnNewPeerConnection(peer);
            }
        }
    }
    
    //// Publish callbacks
    void OnPubNubTheyGotMessage(object result)
    {
      
    }
    void OnPubNubMessageFailed(PubnubClientError clientError)
    {
        throw new Exception("PubNub error on publish: " + clientError.Message);
    }
