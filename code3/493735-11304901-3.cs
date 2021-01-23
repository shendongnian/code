    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using dynamic = System.Linq.Dynamic;
    using System.Linq.Expressions;
    
    namespace Lib.Extensions
    {
        public static class Utils
        {
            /// <summary>
            /// Sorts by Model property with dynamic expression
            /// </summary>
            /// <param name="list"> </param>
            /// <param name="propertyName"></param>
            /// <param name="sortDirection"> </param>
    public static List<TObject> SortByModelProperty<TObject, TProperty>(this List<TObject> list, Expression<Func<TObject, TProperty>> property, SortDirection sortDirection)
        {
            string propertyName = GetPropertyName(property);
            string exp1 = string.Format("model.{0}", propertyName);
            var p1 = Expression.Parameter(typeof(TObject), "model");
            var e1 = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p1 }, null, exp1);
            if (e1 != null)
            {
                if (sortDirection == SortDirection.Ascending)
                {
                    var result = list.OrderBy((Func<TObject, TProperty>)e1.Compile()).ToList();
                    return result;
                }
                else
                {
                    var result = list.OrderByDescending((Func<TObject, TProperty>)e1.Compile()).ToList();
                    return result;
                }
            }
            return list;
        }
        private static string GetPropertyName<TObject, TProperty>(Expression<Func<TObject, TProperty>> property)
        {
            MemberExpression memberExpression = (MemberExpression)property.Body;
            PropertyInfo propertyInfo = (PropertyInfo)memberExpression.Member;
            return propertyInfo.Name;
        }
        }
    }
