    public static string MyValidationSummary(this HtmlHelper helper) 
    {
        string errorMessage = string.Empty;
        if (!helper.ViewData.ModelState.IsValid)
        {
            errorMessage += "<div class='alert'>";
            foreach (var key in helper.ViewData.ModelState.Keys) 
            {
                foreach(var err in helper.ViewData.ModelState[key].Errors)
                    errorMessage += "<span>" + helper.Encode(err.ErrorMessage) + "</span> <br>";
            }
            errorMessage += "</div>";           
        }
        return errorMessage.ToString();
    }
