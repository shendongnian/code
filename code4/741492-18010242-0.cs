    Controller mypage
    {
        ActionResult Index(string color)
        {
            // normal code
        }
    }
    Controller meineseite
    {
        ActionResult Index(string farbe)
        {
            return mypage.Index(farbe);
        }
    }
