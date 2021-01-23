    @model MvcApplication1.Models.AnswersViewModel
    @{
        ViewBag.Title = "Index";
    }
    @using (Html.BeginForm("Index", "Answers", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        @Html.EditorFor(x => x.Answers)
        <input name="submit" type="submit" value="Submit" />
    }
