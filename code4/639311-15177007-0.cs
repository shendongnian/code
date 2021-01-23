    using System;
    using System.Net;
    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                string result = client.DownloadString("http://www.lfp.fr/ligue1/feuille_match/showStatsJoueursMatch?matchId=52255&domId=112&extId=24&live=0&domNomClub=AJ+Auxerre&extNomClub=FC+Nantes");
                Console.WriteLine(result);
            }
        }
    }
