    const int startingTTL = 100;
    const string delimiter = "%";
    while(true)
    {
        String[] path =  queue.pop().Split(delimiter.ToCharArray());
        int ttl = path.Length > 1?--path[1]:startingTTL;
        if(process(path[0]))
        {
            Console.WriteLine("Good!");
        }
        else if (ttl > 0)
        {
            queue.pushback(string.Format("{0}{1}{2}", path[0], delimiter,ttl));             
        }
        else
        {
            Console.WriteLine("TTL expired for path: {0}" path[0]);
        }
    }
