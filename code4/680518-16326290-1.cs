    @model RazorListTest.Models.AnswerScheme 
    <table>
    @for (int i = 0; i < Model.Answers.Count; i++) {
        <tr>
            <td>
                @Html.HiddenFor(model => Model.Answers[i].IsMissing)
                @Html.TextBoxFor(model => Model.Answers[i].Value, new { @class = "inputValue" })
            </td>
            <td>
                @Html.TextBoxFor(model => Model.Answers[i].Text, new { @class = "inputAnswer" })
            </td>
            <td><span class="span-delete" data-answer-scheme-id="@Model.Id" data-answer-id="@Model.Answers[i].Id" >x</span></td>
        </tr>
    }
    </table>
