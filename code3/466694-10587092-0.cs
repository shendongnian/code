        protected void Page_Load(object sender, EventArgs e)
        {
            BuildControl(GetLabelData());
        }
        private Tuple<string, string> GetLabelData()
        {
            if (Page.IsPostBack)
                return (Tuple<string, string>)ViewState["MyLabelData"];
            else
                return new Tuple<string, string>("lblTest", "Test");
        }
        private void BuildControl(Tuple<string, string> t)
        {
            Label l = new Label();
            l.ID = t.Item1;
            l.Text = t.Item2;
            ViewState["MyLabelData"] = t;
            plcSplitter.Controls.Add(l);
        }
        protected void bDoSomething_Click(object sender, EventArgs e)
        {
            Response.Write(String.Format("plcSplitter.Controls.Count:{0}", plcSplitter.Controls.Count));
        }
