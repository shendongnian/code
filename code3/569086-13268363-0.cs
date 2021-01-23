    public event OfferBookmarkRemoved
    {
       add
       {
           userControl.OfferBookmarkRemoved += value;
       }
       remove
       {
           userControl.OfferBookmarkRemoved -= value;
       }
    }
