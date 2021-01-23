    @for (var i = 0; i < Model.SurveyHeaders.Count; i++)
    {
        <h1>@Model.SurveyHeaders[i].Name</h1>
        for (var j = 0; j < Model.SurveyHeaders[i].SubHeaders.Count; j++)
        {
            <h2>@Model.SurveyHeaders[i].SubHeaders[j].Name</h2>
            for (var k = 0; k < Model.SurveyHeaders[i].SubHeaders[j].Questions.Count; k++)
            {
                @Html.RadioButtonFor(x => x.SurveyHeaders[i].SubHeaders[j].Questions[k].Value , 1);
                @Html.RadioButtonFor(x => x.SurveyHeaders[i].SubHeaders[j].Questions[k].Value , 2);
                @Html.RadioButtonFor(x => x.SurveyHeaders[i].SubHeaders[j].Questions[k].Value , 3);            
                @Model.SurveyHeaders[i].SubHeaders[j].Questions[k].Question
            }
        }
    }
