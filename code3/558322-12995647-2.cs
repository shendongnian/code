    public class FanBook
    {
        // use a common constructor
        public FanBook(string url)
        {
            grabHtml(url);
            // ...
        }
        protected string grabHtml(string address) { // SNIP }
        protected void CreateStoryHeader() { // SNIP }
        // other common methods which are the same for every subclass (maybe BuildToc, GetStory, etc.)
        // maybe if you want some easy access to attributes, you could add a dictionary
        public void Dictionary<string, string> Attributes;
        // Then use abstract methods to define methods that are different for subclasses
        protected abstract void GrabStoryVariables();
        protected abstract void GenerateStoryInfo();
    }
