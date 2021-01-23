    protected void Page_Load(object sender, EventArgs e)
    {
        using (resultatEntities datakoppling = new resultatEntities()) 
        {
            var averages = 
                from s in datakoppling.surveyAnswers
                group s by 0 into g
                select new 
                {
                    question1 = g.Average(s => s.question1),
                    question2 = g.Average(s => s.question2),
                    question3 = g.Average(s => s.question3),
                    ...
                };
            grdResult.DataSource = averages;
            grdResult.DataBind();
        }
    }
