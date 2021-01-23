        private static void Main(string[] args)
        {
            var userProfiles = GenerateUserProfiles();
            var idList = GenerateIds();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            userProfiles.Join(idList, up => up.ID, id => id, (up, id) => up).ToArray();
            Console.WriteLine("Elapsed .Join time: {0}", stopWatch.Elapsed);
            stopWatch.Restart();
            userProfiles.Where(up => idList.Contains(up.ID)).ToArray();
            Console.WriteLine("Elapsed .Where .Contains time: {0}", stopWatch.Elapsed);
            Console.ReadLine();
        }
        private static IEnumerable<int> GenerateIds()
        {
           // var result = new List<int>();
            for (int i = 100000; i > 0; i--)
            {
                yield return i;
            }
        }
        private static IEnumerable<UserProfile> GenerateUserProfiles()
        {
            for (int i = 0; i < 100000; i++)
            {
                yield return new UserProfile {ID = i};
            }
        }
