    public class OfferEqualityComparer: IEqualityComparer<OfferOverviewViewModel> {
    
       public bool Equals(OfferOverviewViewModel x, OfferOverviewViewModel y) {
          return Equals(x.OfferId, y.OfferId);
       }
       public int GetHashCode(OfferOverviewViewModel x) {
          return x.OfferId.GetHashCode();
       }
    
    }
    Offers = (from o in offerCategories
                         orderby o.RewardCategory.Ordering, o.Order  
                         where o.RewardOffer.IsDeleted == false
                         select new OfferOverviewViewModel
                         {
                             Partner = o.RewardOffer.Partner,
                             Description = String.Format("{0} {1}", o.RewardOffer.MainTitle, o.RewardOffer.SecondaryTitle),
                             OfferId = o.OfferId,
                             FeaturedOffer = o.RewardOffer.FeaturedOfferOrder.HasValue,
                             Categories = from c in offerCategories.Where(oc => oc.OfferId == o.OfferId)
                                          orderby c.RewardCategory.Ordering
                                          select new CategoryDetailViewModel
                                          {
                                              Description = c.RewardCategory.DisplayName
                                          }
    
                         })
       .Distinct(new OfferEqualityComparer());
