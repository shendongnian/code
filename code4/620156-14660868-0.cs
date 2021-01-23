    public sealed class MySingleInstanceClass
    {
        private static volatile MySingleInstanceClass instance;
        private static object syncRoot = new Object();
        private Bitmap myImage;
        private MySingleInstanceClass() 
        {
            myImage = new Bitmap(100, 100);
        }
        public static MySingleInstanceClass Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new MySingleInstanceClass();
                    }
                }
                return instance;
            }
        }  
        public Bitmap MyImage
        {
            get
            {
                lock (syncRoot)
                    return myImage;
            }
            private set
            {
                lock (syncRoot)
                    myImage = value;
            }
        }
        public void Refresh()
        {
            lock (syncRoot)
            {
                var g = Graphics.FromImage(myImage);
                // do more processing
            }
        }
    }
