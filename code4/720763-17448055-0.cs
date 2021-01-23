    public class OfferVM
    {
        ....
    }
    public class CreateViewModel {
        public IList<OfferVM> Offers { get; set; }
        public OfferVM Header {
            get {
                return Offers.FirstOrDefault();
            }
        }
    }
