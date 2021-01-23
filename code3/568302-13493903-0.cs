    public class MyViewModel
    {
        private static MyViewModel instance;
        private MyViewModel()
        {
            // Private constructor
        }
        public static MyViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new MyViewModel();
                return instance;
            }
        }
    }
