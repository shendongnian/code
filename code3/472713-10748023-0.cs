    public class CityViewModel {
        private readonly List<City.Detail> details;
        public CityViewModel() {
            // Here you assign a List to details
        }
        public ICollection<City.Detail> Details {
            get {
                return details.AsReadOnly();
            }
        }
    }
