    struct CoordData
    {
        public float X, Y, Z, Alpha, Theta, Phi;
        public int NIndex;
    }
    private List<CoordData> coordDataList = new List<CoordData>();
    private ReaderWriterLockSlim lockObj = new ReaderWriterLockSlim();
    private void ReceiveData() 
    {
       IPEndPoint remoteIP = new IPEndPoint(IPAddress.Parse("10.0.2.217"), port);
       client = new UdpClient(remoteIP);
        while (true) 
        {
           try 
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                data = client.Receive(ref anyIP);
                int nIndex = 0;
                foreach(SignalIndex si in xmlreader.cdpSignals)
                {
                     x= ReadSingleBigEndian(data, si.index + 0);
                     y= ReadSingleBigEndian(data, si.index + 4);
                     z= ReadSingleBigEndian(data, si.index + 8);
                     alpha= ReadSingleBigEndian(data, si.index + 12);
                     theta= ReadSingleBigEndian(data, si.index + 16);
                     phi= ReadSingleBigEndian(data, si.index + 20);
                     lockObj.EnterWriteLock();
                     try
                     {
                         coordDataList.Add(new CoordData() { X = x, Y = y, Z = z, Alpha = alpha, Theta = theta, Phi = phi, NIndex = nIndex });
                     }
                     finally
                     {
                         lockObj.ExitWriteLock();
                     }
                     nIndex++; //I'm assuming you want to do this here otherwise you'll be changing the same object in the array every time  
                }
            }
            catch (Exception err) 
            {
               print(err.ToString());
            }
        }
        client.Close();
    }
    void Update()
    {
        lockObj.EnterReadLock();
        try
        {
            foreach (CoordData data in coordDataList)
            {
                xmlReader.unityGameObjects[data.NIndex].localPosition = new Vector3(data.X,data.Y,data.Z);
                xmlReader.unityGameObjects[data.NIndex].Rotate(data.Alpha,data.Theta,data.Phi);
            }
        }
        finally
        {
            lockObj.ExitReadLock();
        }
    }
