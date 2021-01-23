    public interface IAssignOffer
    {
        int OwnerId {get;}
        Offer AssignOffer(OfferType offerType, IOfferValueCalc valueCalc);
        IEnumerable<Offer> NewOffers {get; }
    }
 
    public class Member:IAssignOffer
    {
        /* implementation */ 
     }
     public interface IDomainRepository
     {
        void Save(IAssignOffer member);    
     }
