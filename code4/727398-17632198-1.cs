    public partial class DetectTag : PhoneApplicationPage
    {
        int uid;
        public DetectTag()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("uid"))
            {
                uid = int.Parse(NavigationContext.QueryString["uid"]);
            }
            base.OnNavigatedTo(e);
            string stringUid = uid.ToString();
            tagID.Text = stringUid;
        }
    }
