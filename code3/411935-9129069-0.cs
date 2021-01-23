    public ActionResult Feed(int? page = 1)
    {
        IKernel kernel =  // get the kernel from somewhere
        var mgr = kernel.Get<SyndicationManager>();
        return mgr.GetFeedResult(page);
    }
