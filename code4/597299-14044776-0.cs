    @using (Html.BeginForm())
    {
        @HtmlHiddenFor(m => m.Id)
        <div>First - @Html.CheckBoxFor(m => m.First)</div>
        <div>Second - @Html.CheckBoxFor(m => m.First)</div>
        <div>Third - @Html.CheckBoxFor(m => m.First)</div>
        <input type="submit">
    }
    [HttpPost]
    public ActionResult SomeActionMethod(int id)
    {
        var model = new MyClass(); // build your model however you like
        TryUpdateModel(model);
    }
