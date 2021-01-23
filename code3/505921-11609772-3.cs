    protected void QuestionsRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType ==    
        ListItemType.AlternatingItem))
        {
            Question q = (Question)e.Item.DataItem;
            var answers = dc.Answers.Where(a => a.questionId == q.id).ToList();
            Repeater answersRep = (Repeater)e.Item.FindControl("answersRep");
            answersRep.DataSource = answers;
            answersRep.DataBind();
        }
    }
