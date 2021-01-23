    private object locker;
    private int _likes = 0;
    private int Likes
    {
        get
        {
            lock(locker)
            {
                return _likes;
            }
        }
        set
        {
            lock(locker)
            {
                _likes = value;
            }
        }
    }
    void MyMethod()
    {
        Parallel.ForEach(entries, entry =>
        {
            using(WebClient client = new WebClient())
            using(Stream data = client.OpenRead(url))
            using(StreamReader reader = new StreamReader(data))
            {
            ....
            }
        }
    }
