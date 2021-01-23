    struct SendComThreadParams
    {
    public string IP;
    public string Com;
    public SendComThreadParams(string ip, string com)
    {
        this.IP = ip;
        this.Com = com;
    }
    }
    private void sendCom(String com)
    {
    //send command to selected item
    int i=0;
    String IP;
    foreach (var item in checkedListBox1.CheckedItems)
    {
        Console.WriteLine(item.ToString());
        IP = item.ToString();
        ThreadPool.QueueUserWorkItem(new WaitCallback(sendComThread), (object)new SendComThreadParams(IP, com));
        i++;
    }
    }
    private void sendComThread(object threadParam)
    {
    var p = (SendComThreadParams)threadParam;
    // send an command
    System.Console.WriteLine(p.IP + p.Com);
    }
    
