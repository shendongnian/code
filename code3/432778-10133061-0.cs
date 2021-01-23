        public static class AddressExtensions
        {
        
        
        public static double CalculateDistanceTo(this Address address1, double longitude, double latitude)
        {
            if (address1 == null)
            {
                return 0;
            }
            return Global.CalculateDistance((double?)address1.Longitude, (double?)address1.Latitude, longitude, latitude);
        }
        public static double CalculateDistanceTo(this Address address1, Address address)
        {
            if (address1 == null || address == null)
            {
                return 0;
            }
            return Global.CalculateDistance((double?)address1.Longitude, (double?)address1.Latitude, (double?)address.Longitude, (double?)address.Latitude);
        }
        public static double CalculateDistanceTo(this Address address1, User user)
        {
            if (address1 == null)
            {
                return 0;
            }
            return address1.CalculateDistanceTo(user.Addresses.FirstOrDefault());
        }
        public static double CalculateDistanceTo(this Address address1, Place place)
        {
            if (address1 == null)
            {
                return 0;
            }
            return address1.CalculateDistanceTo(place.Addresses.FirstOrDefault());
        }
        }
