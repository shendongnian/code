    public class MyApplicationContext:ApplicationContext
    {
        public Form CurForm;
        ManualResetEvent ready = new ManualResetEvent(false);
        public MyApplicationContext()
        {
            CurForm=new Animation();
            CurForm.Show();
        }
    }
    class Manager
    {
        private MyApplicationContext CurContext;
        
        Thread curt;
        void start()
        {
            try
            {
                CurContext = new MyApplicationContext();
                Application.Run(CurContext);
            }
            catch
            {
                CurContext.CurForm.Close(); 
            }
        }
        private void Init()
        {
            curt = new Thread(start);
            curt.SetApartmentState(ApartmentState.STA);
            curt.IsBackground = true;
            curt.Start(); 
        }
        public static Manager Active
        {
            get
            {
                if (active == null)
                {
                    active = new Manager();
                    
                }
                return active;
            }
        }
        private static Manager active;
        public static void Show()
        {
            Active.Init();           
        }
        public static void Hide()
        {
            Active.curt.Abort();                        
        }
