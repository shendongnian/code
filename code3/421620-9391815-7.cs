    public class MyViewModel
    {
        public List<String> Items
        {
            get { return new List<String> { "One", "Two", "Three" }; }
        }
    }
    //This can be done in the Loaded event of the page:
    DataContext = new MyViewModel();
