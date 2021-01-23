    protected void Page_Load(object sender, EventArgs e)
    {
        using (resultatEntities datakoppling = new resultatEntities()) 
        {
            var answers = 
                from s in datakoppling.surveyAnswers
                select new 
                {
                    id = s.Id,
                    question1 = (double)s.question1,
                    question2 = (double)s.question2,
                    question3 = (double)s.question3,
                    ...
                };
            var averages = 
                from s in datakoppling.surveyAnswers
                group s by 0 into g
                select 
                {
                    id = 0,
                    question1 = g.Average(s => s.question1),
                    question2 = g.Average(s => s.question2),
                    question3 = g.Average(s => s.question3),
                    ...
                };
            grdResult.DataSource = answers.Union(averages);
            grdResult.DataBind();
        }
    }
