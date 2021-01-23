    IList<Model.question> lstQuestion = qn.GetRecords(taskID, activityID);
    
            for(int i = 0 ; i <lstQuestion.Count()-1 ; i++)
            {
                 .... //code here
    
                if(lstQuestion[i].QuestionNo == lstQuestion[++i].QuestionNo) // error at i++
                {
                    tb.Text = lstQuestion[i].QuestionContent;
                    sp1.Children.Add(tb);
                }
