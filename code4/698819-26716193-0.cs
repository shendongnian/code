        private static void Main(string[] args)
        {
            List<UserProfile> userProfiles = GenerateUserProfiles();
            List<int> idList = GenerateIds();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            userProfiles.Join(idList, up => up.ID, id => id, (up, id) => up).ToArray();
            Console.WriteLine("Elapsed .Join time: {0}", stopWatch.Elapsed);
            stopWatch.Restart();
            userProfiles.Where(up => idList.Contains(up.ID)).ToArray();
            Console.WriteLine("Elapsed .Where .Contains time: {0}", stopWatch.Elapsed);
            Console.ReadLine();
        }
        private static List<int> GenerateIds()
        {
            var result = new List<int>();
            for (int i = 100000; i > 0; i--)
            {
                result.Add(i);
            }
            return result;
        }
        private static List<UserProfile> GenerateUserProfiles()
        {
            var result = new List<UserProfile>();
            for (int i = 0; i < 100000; i++)
            {
                result.Add(new UserProfile {ID = i});
            }
            return result;
        }
