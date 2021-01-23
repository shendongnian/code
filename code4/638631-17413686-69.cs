    private RecordView.IFragmentToViewPagerEvent _fragmentToViewPagerEvent;
    public override void OnAttach(Activity activity)
    {
        base.OnAttach(activity);
        _fragmentToViewPagerEvent = (RecordView.IFragmentToViewPagerEvent) activity;
    }
