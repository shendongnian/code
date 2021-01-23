    public void Trousers(int i)
    {
       Console.WriteLine(i);
    }
    public Action<int> serialpacket
    {
        get { return Trousers; }
    }
