    public class MainPage
    {
        private GroupingZoomedInView gView;
        public void SomeMethod()
        {
            Func<string> method = gView.GetTemplateMethod();
            string temp = method(); // executes the method
        }
    }
