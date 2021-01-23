        public static bool waittopuielm(string appname, int retries = 1000, int retrytimeout = 1000)
        {
            bool foundMatch = false;
            for (int i = 1; i <= retries; i++)
            {
                if (findtopuielm(appname))
                {
                    foundMatch = true;
                    break;
                }
                else
                {
                    Console.WriteLine("No match found, sleeping...");
                }
                Thread.Sleep(retrytimeout);
            }
            return foundMatch;
        }
