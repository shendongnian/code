    public ViewResult Index(string accTok, string fullImgPath)
    {
        ViewModel.Acctok = accTok;
        ViewModel.FullImgPath = fullImgPath;
        return View();
    }
    public ViewResult Publish(string accTok, string fullImgPath)
    {
        SomeProcessing(accTok,fullImgPath);
        return View();
    }
