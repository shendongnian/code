    while(true)
    {
        try 
        {
            String[] path =  queue.pop().Split(delimiter.ToCharArray());
            int ttl = path.Length > 1?--int.Parse(path[1]):startingTTL;
        
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
        catch(InvalidOperationException ex)
        {
            //Queue.Dequeue throws InvalidOperation if the queue is empty... sleep for a bit before trying again
            Thread.Sleep(100);
        }
    }
