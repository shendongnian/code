    public MyPage: Page
    {
    
        protected string GetLink()
        {
            return ConfigurationManager.AppSettings["someKey"];
        }
    
    }
