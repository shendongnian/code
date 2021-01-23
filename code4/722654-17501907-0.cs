    public interface IListing
    {
        void DeleteItem(int id);
    }
    public AntiqueSellerListing : IListing
    {
        public void DeleteItem(int id)
        {
            ... delete logic
        }
    }
    public class MyClass
    {
        public void DeleteEntity<T>(T listing, int id)
            where T : IListing
        {
            SystemLogic.DeleteItem<T>(listing, id);
        }    
    }
    public static class SystemLogic
    {
        public void DeleteItem<T>(T listing, int id)
            where T : IListing
        {
            listing.DeleteItem(id);
        }  
    }
