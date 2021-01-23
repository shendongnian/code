    using System.Web.Helpers;
    [HttpPost]
    [ValidateInput(false)]
    public ViewResult Edit(ContentTemplateView contentTemplateView)
    {
        FormCollection collection = new FormCollection(Request.Unvalidated().Form);
