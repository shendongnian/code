    var form = System.Web.HttpContext.Current.Request.Form;
    if (form != null && !String.IsNullOrEmpty(day) && form.AllKeys.Contains(day))
    {
        var test = form[day].ToString();
    }
