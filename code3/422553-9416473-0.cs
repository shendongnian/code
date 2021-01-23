    public class DAL {
        private List<Advertisement> _activeAdvertisements;
        public List<Advertisement> GetActiveAdvertisements() 
        {
            return _activeAdvertisements ?? _activeAdvertisements = // ... data access;
        }
        public void InsertActiveAdvertisements(Advertisement newAdvertisement)
        {
            var adList = GetActiveAdvertisements();
            adList.Add(newAdvertisements);
            // ... Add values to the database
        }
    }
