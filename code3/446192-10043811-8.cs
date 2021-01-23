    private const int InitialToolTipDelay = 500, MaxToolTipDisplayTime = 2000;
    private ToolTip toolTip = new ToolTip();
    private Timer timer = new Timer();
    private TreeNode toolTipNode;
    public frmTreeViewWithToolTip()
    {
        InitializeComponent();
        toolTip.IsBalloon = true;
        timer.Tick += new EventHandler(timer_Tick);
    }
