    class formdlg
    {
        static formdlg instance;
        public static formdlg GetInstance()
        {
            if (instance == null)
                instance = new formdlg();
            return instance;
        }
    }
