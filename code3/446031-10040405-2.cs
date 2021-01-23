    protected void lvQuestions_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Literal litQuestion = (Literal)e.Item.FindControl("litQuestion");
            Literal litAnswer = (Literal)e.Item.FindControl("litAnswer");
    
    
            YourClass item = e.Item.DataItem as YourClass;
            litQuestion.Text = item.Question;
            litAnswer.Text = item.Answer;
         }
     }
