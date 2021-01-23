    private ParcelView.IFragmentToViewPagerEvent _fragmentToViewPagerEvent;
    public override void OnAttach(Activity activity)
    {
        base.OnAttach(activity);
        _fragmentToViewPagerEvent = (ParcelView.IFragmentToViewPagerEvent) activity;
    }
