    private const int InitialToolTipDelay = 500, MaxToolTipDisplayTime = 2000;
    ToolTip toolTip = new ToolTip();
    Timer timer = new Timer();
    TreeNode toolTipNode;
    public frmTreeViewWithToolTip()
    {
        InitializeComponent();
        toolTip.IsBalloon = true;
        timer.Tick += new EventHandler(timer_Tick);
    }
