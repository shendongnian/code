    // ~/Views/_controller_/_action_.cshtml
    @model QuizzClass
    @using (Html.BeginForm())
    {
      for (var q = 0; q < Model.Questions.Length; q++)
      {
        // ~/Views/Shared/EditorTemplates/Question.cshtml
        @Html.EditorFor(x => Model.Questions[q]);
      }
    }
