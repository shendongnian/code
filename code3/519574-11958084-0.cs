    if(!Page.IsPostback)
    {
     var paperID = Session["paperID"].ToString(); 
            QuestionPaper = repository.GetPaper(Int32.Parse(paperID)); 
            r.DataSource = QuestionPaper.Questions; 
            r.DataBind(); 
    }
