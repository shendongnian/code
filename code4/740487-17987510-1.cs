    @model IList<Quiz.Models.Question>                                
    
    <h2>Welcome to the Quiz</h2>
    @Html.BeginForm( method:FormMethod.Post, controllerName:"Home", actionName:"index")
    {
        @for (var i = 0; i < Model.Count; i++)
        {
            @Html.HiddenFor(x => x[i].QuestionID)
            <fieldset>
                <legend>
                    @Html.DisplayFor(x => x[i].QuestionBody)
                </legend>
                <ul>
                    <li>
                        @Html.HiddenFor(x => x[i].CorrectAnswer)
                        @Html.RadioButtonFor(x => x[i].SelectedAnswer, Model[i].CorrectAnswer)
                        @Html.DisplayFor(x => x[i].CorrectAnswer)
                    </li>
                    <li>
                        @Html.HiddenFor(x => x[i].AlternativeAnswer)
                        @Html.RadioButtonFor(x => x[i].SelectedAnswer, Model[i].AlternativeAnswer)
                        @Html.DisplayFor(x => x[i].AlternativeAnswer)
                    </li>
                </ul>
            </fieldset>
        }
    
        <button type="submit">OK</button>
    }
