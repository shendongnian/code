    public class MyModel
    {
        private Guid myGuid = Guid.NewGuid();
        public MyModel(Guid guid)
        {
            myGuid = guid;
        }
        public Guid MyGuid
        {
            get { return myGuid; }
            set { myGuid = value; }
        }
    }
