    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    
        public static class Extensions
        {
            public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> modelExpression, string firstElement)
            {
                var typeOfProperty = modelExpression.ReturnType;
                if (!typeOfProperty.IsEnum)
                {
                    throw new ArgumentException(string.Format("Type {0} is not an enum", typeOfProperty));
                }
    
                Dictionary<int, string> KeyValuePair = new Dictionary<int, string>();
                Array EnumValues = Enum.GetValues(typeOfProperty);
                foreach (var item in EnumValues)
                {
                    KeyValuePair.Add((int)item, item.ToString());
                }
    
                var selectList = new SelectList(KeyValuePair, "Key", "Value");
                return htmlHelper.DropDownListFor(modelExpression, selectList, firstElement);
            }
        }
