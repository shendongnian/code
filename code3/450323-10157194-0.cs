    public interface ISearchable
    {
        void GetSearchResult();
    }
    
    public class MyPage : Page, ISearchable
    {
        public void GetSearchResult() {
            HelperClass.HelperMethod(this); // Pass in
        }
    }
    public static class HelperClass
    {
        public static void HelperMethod(ISearchable page) {
            page.GetSearchResult();
        }
    }
