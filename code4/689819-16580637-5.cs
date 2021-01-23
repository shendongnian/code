    var url = ConfigurationManager.AppSettings["resourcePath"];
    Html.AppendCssFileParts( url + "/Content/smoothness/jquery-ui-1.8.17.custom.css"); 
    Html.AppendScriptParts(url + "/Scripts/public.ajaxcart.js");
    Html.AppendScriptParts(url + "/Scripts/public.common.js");
    Html.AppendScriptParts(url + "/Scripts/jquery-ui.min.js");
    Html.AppendScriptParts(url + "/Scripts/jquery.validate.unobtrusive.min.js");
    Html.AppendScriptParts(url + "/Scripts/jquery.validate.min.js");
    Html.AppendScriptParts(url + "/Scripts/jquery.unobtrusive-ajax.min.js");
    Html.AppendScriptParts(url + "/Scripts/jquery-1.7.1.min.js");
