    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    
    namespace Proj.Helpers
    {
        public static class HtmlHelpers
        {
            public static IHtmlContent HiddenForEnumerable<TModel, TModelProperty>(this IHtmlHelper<TModel> helper,
        Expression<Func<TModel, IEnumerable<TModelProperty>>> expression, params Expression<Func<TModelProperty, object>>[] memberPropsExpressions)
            {
                var hcb = new HtmlContentBuilder();
    
                var membername = expression.GetMemberName();
                var model = helper.ViewData.Model;
                var list = expression.Compile()(model);
    
                var memPropsInfo = memberPropsExpressions.Select(x => new
                {
                    MemberPropName = x.GetMemberName(),
                    ListItemPropGetter = x.Compile()
                }).ToList();
    
                for (var i = 0; i < list.Count(); i++)
                {
                    var listItem = list.ElementAt(i);
                    if (memPropsInfo.Any())
                    {
                        foreach (var q in memPropsInfo)
                        {
                            hcb.AppendHtml(helper.Hidden(string.Format("{0}[{1}].{2}", membername, i, q.MemberPropName), q.ListItemPropGetter(listItem)));
                        }
                    }
                    else
                    {
                        hcb.AppendHtml(helper.Hidden(string.Format("{0}[{1}]", membername, i), listItem));
                    }
                }
    
                return hcb;
            }
    
            /// <summary>
            /// Returns hiddens for every IEnumerable item, with it's all public writable properties, if allPublicProps set to true.
            /// </summary>
            public static IHtmlContent HiddenForEnumerable<TModel, TModelProperty>(this IHtmlHelper<TModel> helper,
               Expression<Func<TModel, IEnumerable<TModelProperty>>> expression, bool allPublicProps)
            {
                if (!allPublicProps)
                    return HiddenForEnumerable(helper, expression);
    
                var hcb = new HtmlContentBuilder();
    
                var membername = expression.GetMemberName();
                var model = helper.ViewData.Model;
                var list = expression.Compile()(model);
    
                var type = typeof(TModelProperty);
                var memPropsInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.GetSetMethod(false) != null && x.GetGetMethod(false) != null)
                    .Select(x => new
                    {
                        MemberPropName = x.Name,
                        ListItemPropGetter = (Func<TModelProperty, object>)(p => x.GetValue(p, null))
                    }).ToList();
    
                if (memPropsInfo.Count == 0)
                    return HiddenForEnumerable(helper, expression);
    
                for (var i = 0; i < list.Count(); i++)
                {
                    var listItem = list.ElementAt(i);
                    foreach (var q in memPropsInfo)
                    {
                        hcb.AppendHtml(helper.Hidden(string.Format("{0}[{1}].{2}", membername, i, q.MemberPropName), q.ListItemPropGetter(listItem)));
                    }
                }
    
                return hcb;
            }
    
            public static string GetMemberName<TModel, T>(this Expression<Func<TModel, T>> input)
            {
                if (input == null)
                    return null;
    
                MemberExpression memberExp = null;
    
                if (input.Body.NodeType == ExpressionType.MemberAccess)
                    memberExp = input.Body as MemberExpression;
                else if (input.Body.NodeType == ExpressionType.Convert)
                    memberExp = ((UnaryExpression)input.Body).Operand as MemberExpression;
    
                return memberExp != null ? memberExp.Member.Name : null;
            }
        }
    }
