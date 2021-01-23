    @model SoQna.ViewModels.QnaViewModel
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Hahah</h2>
    
    @using (Html.BeginForm("SubmitAnswers", "Home"))
    {
        
        
        int i = 0;
        foreach (var answer in Model.Answers)
        {
            @: Question #@(answer.ToQuestionId) <br />
                    
            @Html.Hidden("Answers[" + i + "].ToQuestionId", answer.ToQuestionId)
           
            @Html.Label("Answers[" + i + "].QuestionText", answer.QuestionText)
    
            @* to save bandwidth we didn't put the Question's text on submit *@
    
            <br />
                                              
            @Html.TextArea("Answers[" + i + "].AnswerText", answer.AnswerText)
    
            <hr />
            
            ++i;
            
        }
        
        <input type="submit" value="Done" />
    }
