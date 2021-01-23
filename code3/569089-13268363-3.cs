    public class OfferEventArgs : EventArgs
    {
       public int OfferID { get; set; }
    }
    
    public event EventHandler<OfferEventArgs> OfferBookmarkRemoved;
