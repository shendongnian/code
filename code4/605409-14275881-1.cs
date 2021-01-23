    object obj = 
      allowMultiple ? htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string[])) : 
        htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string));
    if (!flag && obj == null && !string.IsNullOrEmpty(name))
    {
      obj = htmlHelper.ViewData.Eval(name);
    }
    if (obj != null)
    {
      selectList = 
        SelectExtensions.GetSelectListWithDefaultValue(selectList, obj, allowMultiple);
    }
