    for(int i = 0 ; i <lstQuestion.Count(); i++)
            {
                 .... //code here
    
                if(lstQuestion[i].QuestionNo == 1stQuestion[i+1].QuestionNo) // error at i++
                {
                    tb.Text = lstQuestion[i+1].QuestionContent;
                    sp1.Children.Add(tb);
                }
