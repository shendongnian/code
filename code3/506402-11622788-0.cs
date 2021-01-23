        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var d = new QuestionsContext().GetQuestions();
                this.repeater.DataSource = d;
                this.repeater.DataBind();
            }
        }
        protected void getContent_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            this.generic.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
            string s = sb.ToString();
            this.Trace.Warn(Server.HtmlEncode(s));
            this.message.Text = Server.HtmlEncode(s);
        }
