    <table>        
        @Html.Partial("_InformationEdit", Model.Information, 
            new ViewDataDictionary(Html.ViewDataContainer.ViewData) 
            {
                TemplateInfo = new System.Web.Mvc.TemplateInfo { HtmlFieldPrefix = "Information" }
            })
    </table>
