    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    
    namespace StackOverflowSplitStringAttribute.Infrastructure.Attributes
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class SplitStringAttribute : ActionFilterAttribute
        {
            public string Parameter { get; set; }
    
            public string Delimiter { get; set; }
    
            public SplitStringAttribute()
            {
                Delimiter = ",";
            }
    
            public override void OnActionExecuting(HttpActionContext filterContext)
            {
                if (filterContext.ActionArguments.ContainsKey(Parameter))
                {
                    var qs = filterContext.Request.RequestUri.ParseQueryString();
                    if (qs.HasKeys())
                    {
                        var value = qs[Parameter];
    
                        var listArgType = GetParameterEnumerableType(filterContext);
    
                        if (listArgType != null && !string.IsNullOrWhiteSpace(value))
                        {
                            string[] values = value.Split(Delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
                            var listType = typeof(List<>).MakeGenericType(listArgType);
                            dynamic list = Activator.CreateInstance(listType);
    
                            foreach (var item in values)
                            {
                                try
                                {
                                    dynamic convertedValue = TypeDescriptor.GetConverter(listArgType).ConvertFromInvariantString(item);
                                    list.Add(convertedValue);
                                }
                                catch (Exception ex)
                                {
                                    throw new ApplicationException(string.Format("Could not convert split string value to '{0}'", listArgType.FullName), ex);
                                }
                            }
    
                            filterContext.ActionArguments[Parameter] = list;
                        }
                    }
                }
    
                base.OnActionExecuting(filterContext);
            }
    
            private Type GetParameterEnumerableType(HttpActionContext filterContext)
            {
                var param = filterContext.ActionArguments[Parameter];
                var paramType = param.GetType();
                var interfaceType = paramType.GetInterface(typeof(IEnumerable<>).FullName);
                Type listArgType = null;
    
                if (interfaceType != null)
                {
                    var genericParams = interfaceType.GetGenericArguments();
                    if (genericParams.Length == 1)
                    {
                        listArgType = genericParams[0];
                    }
                }
    
                return listArgType;
            }
    
        }
    }
