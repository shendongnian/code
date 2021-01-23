    public class Venue
    {
        public int VenueId {get; set;}
        public string VenueName {get; set;}
        public string PartyName {get; set;}
        public int PartyId {get; set;}
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Venue> venues = new List<Venue>()
            {
                new Venue() { VenueId = 74,
                              VenueName = "CityStars Cinema",
                              PartyName = "Late Night (3am)",
                              PartyId = 2},
                new Venue() { VenueId = 74,
                              VenueName = "CityStars Cinema",
                              PartyName = "Sunrise (6am)",
                              PartyId = 3},
                new Venue() { VenueId = 74,
                              VenueName = "CityStars Cinema",
                              PartyName = "Morning (9am)",
                              PartyId = 4},
                new Venue() { VenueId = 74,
                              VenueName = "CityStars Cinema",
                              PartyName = "Noon (12pm)",
                              PartyId = 5},
                new Venue() { VenueId = 74,
                              VenueName = "CityStars Cinema",
                              PartyName = "After Noon (3pm)",
                              PartyId = 6},
            };
    
            var venuesGrouped = venues.GroupBy(v => v.VenueName).
                        Select(group =>
                            new
                            {
                                VenueId = group.First().VenueId,
                                VenueName = group.Key,
                                VenueShowTimes = "[" + group.
                    Select(v => string.Format(@"{{{0}, {1}}}", v.PartyName, v.PartyId)).
                    Aggregate((party1, party2) =>  party1 + ", " + party2) + "]"
                            });
    
            foreach (var venue in venuesGrouped)
            {
                Console.WriteLine(
                string.Format("{{[\"VenueID\" : {0},\n\"VenueName\" : {1}\n,\"VenueShowTimes\": {2}]}}",
                venue.VenueId, venue.VenueName, venue.VenueShowTimes));
            }
    
    
        }
    }
