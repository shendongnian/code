    public partial class _Default
    {
        protected override void OnInit(EventArgs e)
        {
            this.LoadComplete += RunTest;
            this.Load += new EventHandler(_Default_Load);
            base.OnInit(e);
        }
        void _Default_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        void RunTest(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        protected override void OnPreRender(EventArgs e)
        {
            this.Response.Write("omfgggg");
            this.lblMyMessageTest.Text = "omfg2";
            base.OnPreRender(e);
        }
    }
