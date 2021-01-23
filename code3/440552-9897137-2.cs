        static void Main(string[] args)
        {
            List<string> playlists = new List<string>(){"more and you", "and us", "more"};
            List<string> sync = new List<string>() { "more and you-20120312", "more and you-20120314", "more and you-20120313", "and us-20120313", "and us-20120314", "more-20120314", "more-20120313", "more-20120312" };
            StringBuilder sb = new StringBuilder();
            sb.Append("<h2>Playlist Information</h2>\r\n");
            HashSet<string> finalSyncResult = new HashSet<string>();
            foreach (string play in playlists)
            {
                List<string> currentSyncSet = new List<string>();
                foreach (string s in sync)
                {
                    if (s.StartsWith(play))
                    {
                        currentSyncSet.Add(s);
                    }
                }
                foreach (var syncset in currentSyncSet)
                {
                    if (currentSyncSet.Count < 3)
                    {
                        finalSyncResult.Add("<p class=\"bad\">" + syncset + "</p>");
                    }
                    else
                    {
                        finalSyncResult.Add("<p class=\"good\">" + syncset + "</p>");
                    }
                }
            }
            foreach (var result in finalSyncResult)
            {
                sb.Append(result + "\r\n");
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
