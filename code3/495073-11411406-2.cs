    class Program
    {
        static void Main(string[] args)
        {
            Twitter twitter = new Twitter(**your_consumer_key**, **your_consumer_secret**);
            twitter.Login(**username**, **password**);
            List<TwitterStatus> statuses = twitter.GetMentiones();
            foreach (TwitterStatus status in statuses)
            {
                Console.WriteLine(status.Text);
            }
        }
    }
