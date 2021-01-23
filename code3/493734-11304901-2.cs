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
            public static List<T> SortByModelProperty<T>(this List<T> list, string propertyName, SortDirection sortDirection)
            {
                string exp1 = string.Format("model.{0}", propertyName);
                var p1 = Expression.Parameter(typeof(T), "model");
                var e1 = dynamic.DynamicExpression.ParseLambda(new[] { p1 }, null, exp1);
    
                if (e1 != null)
                {
                    if (sortDirection == SortDirection.Ascending)
                    {
                        var result = list.OrderBy<T, object>((Func<T, object>)e1.Compile()).ToList();
                        return result;
                    }
                    else
                    {
                        var result = list.OrderByDescending<T, object>((Func<T, object>)e1.Compile()).ToList();
                        return result;
                    }
                }
                return list;
            }
        }
    }
