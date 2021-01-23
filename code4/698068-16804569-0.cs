    for(int i = 0; i < tbList.Count; i++)
    {
        //To see the data you're inserting into database.
        Response.Write(tb[i].Text);
        Response.Write(tb[i+1].Text);
        //Insert into database based on your code.
        daoQuestion.Insert(new Model.question 
        { 
            Answer = tb[i].Text,
            QuestionContent = tb[++i].Text,
            TaskName = "Grammar",
            ActivityName = dropListActivity.SelectedItem.Text,
            QuestionNo = testLabel.Text
        });
        daoQuestion.Save();
    }
