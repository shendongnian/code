    var options = Enum.GetValues(typeof(test))// u can pass type as parameter
    .OfType<object>()
    .Select(each => new {key = Enum.GetName(typeof(test), each), value = each})
    .Select(each => string.Format("<option value=\"{1}\">{0}</option>", HttpUtility.HtmlEncode(each.key), each.value))
    .Aggregate((cur, nex) => cur + nex);
    return "<select name=...>"+options+"</select>";
