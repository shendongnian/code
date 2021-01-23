    public class ParentContainer
    {
        private List<Parent> watched = new List<Parent>();
        public void Add(Parent watch)
        {
            watched.Add(watch);
            watch.SomeEvent += Handler;
        }
        private void Handler(object sender, EventArgs args)
        {
            //Do something
        }
    }
