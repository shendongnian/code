    @model BusinessProcess.Models.HelloworldTO
    @if (Model.Edit)
    {
       @using (Html.BeginForm())
       {
          @Html.ValidationSummary(true)
        
          @Html.DisplayNameFor(model => model.Response_Borrower)
          @Html.EditorFor(model => model.Response_Borrower)
        
       }
    }
    else
    {
        @Html.DisplayFor(model => model.Response_Borrower)
     }
