    [System.ComponentModel.DesignerCategory ( "" )]
    public partial class ListViewEx : ListView
    {
        private const int WM_ERASEBKGND = 14;
        /// <summary>
        /// 
        /// </summary>
        public ListViewEx ()
        {
            InitializeComponent ();
            // Turn on double buffering.
            SetStyle ( ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true );
            // Enable the OnNotifyMessage to filter out Windows messages.
            SetStyle ( ControlStyles.EnableNotifyMessage, true );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMsg"></param>
        protected override void OnNotifyMessage ( Message oMsg )
        {
            // Filter out the WM_ERASEBKGND message to prevent the control
            // from erasing the background (and thus avoid flickering.)
            if ( oMsg.Msg != WM_ERASEBKGND )
                base.OnNotifyMessage ( oMsg );
        }
    }
