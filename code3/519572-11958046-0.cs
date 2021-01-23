    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            // do things that only should be done on the first page load
            var paperID = Session["paperID"].ToString();
            QuestionPaper = repository.GetPaper(Int32.Parse(paperID));
            r.DataSource = QuestionPaper.Questions;
            r.DataBind();
        }
    }
