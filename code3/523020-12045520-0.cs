    void SetSelectList<TModel, TProperty>(
       TModel model, 
       Expression<Func<TModel, TProperty>> propertySelector, 
       IEnumerable<SelectListItem> list) {
             
       this.ViewData[ExpressionHelper.GetExpressionText(propertySelector)] = list;
    }
