        for(int i = 0 ; i <lstQuestion.Count()-1; i++)
        {
             .... //code here
            if(lstQuestion[i].QuestionNo == 1stQuestion[i+1].QuestionNo) 
            {
                tb.Text = lstQuestion[i+1].QuestionContent;
                sp1.Children.Add(tb);
            }
