    static class Program
    {
        static void Main()
        {
            const string channelInvalidate = "cache/invalidate";
            using(var pub = new RedisConnection("127.0.0.1"))
            using(var sub = new RedisSubscriberConnection("127.0.0.1"))
            {
                pub.Open();
                sub.Open();
    
                sub.Subscribe(channelInvalidate, (channel, data) =>
                {
                    string key = Encoding.UTF8.GetString(data);
                    Console.WriteLine("Invalidated {0}", key);
                });
                Console.WriteLine(
                        "Enter a key to invalidate, or an empty line to exit");
                string line;
                do
                {
                    line = Console.ReadLine();
                    if(!string.IsNullOrEmpty(line))
                    {
                        pub.Publish(channelInvalidate, line);
                    }
                } while (!string.IsNullOrEmpty(line));
            }
        }
    }
