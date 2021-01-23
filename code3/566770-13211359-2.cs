    @model PostViewModel
    @Html.LabelFor(x=>x.Text);
    @using(Html.Beginform())
    {      
      @Html.HiddenFor(x=>x.ID);     
      @Html.TextBoxFor(x=>x.NewAnswer)
      <input type="submit" />
    }
    <h3>Answers</h3>
    @if(Model.Answers!=null)
    {
      @Html.Partial("Responses.cshtml",Model.Asnwers)
    }
