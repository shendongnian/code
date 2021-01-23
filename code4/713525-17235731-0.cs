        private static Lazy<Dictionary<string, List<MappingFields>>> MappingCollections =
            new Lazy<Dictionary<string, List<MappingFields>>>(x => loadCodes(Location, fileName));
        public void TicketTrack(Tickets[] tickets)
        {
            var myData = MappingCollections.Value;
        }
