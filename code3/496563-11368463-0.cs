    public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    Console.WriteLine("You Have connectity!");
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("No internet connection found.");
                return false;
            }
        }
