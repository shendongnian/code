    TProperty val = expression.Compile().Invoke(htmlHelper.ViewData.Model);
    SelectListItem selectedItem = selectList.Where(item => item.Value == Convert.ToString(val)).FirstOrDefault();
    string text = "";
    if (selectedItem != null) text = selectedItem.Text;
    return !enabled ? new MvcHtmlString("<span>" + text + "</span>")
          : htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);
