    public static MvcHtmlString MyHelper<TModel,object>(
        this HtmlHelper<TModel> helper, 
        Expression<Func<TModel,object>> expression) {
            var newExpression = expression.Body as NewExpression;
            TModel model = helper.ViewData.Model;
            
            foreach (MemberExpression a in newExpression.Arguments) {
                var propertyName = a.Member.Name;
                var propertyValue = GetPropertyValue<TModel>(model, a);
                // Do whatever you need to with the property name and value;
            }
        }
        private static object GetPropertyValue<T>(T instance, MemberExpression me) {
            object target;
                        
            if (me.Expression.NodeType == ExpressionType.Parameter) {
                // If the current MemberExpression is at the root object, set that as the target.            
                target = instance;
            }
            else {                
                target = GetPropertyValue<T>(instance, me.Expression as MemberExpression);
            }
            // Return the value from current MemberExpression against the current target
            return target.GetType().GetProperty(me.Member.Name).GetValue(target, null);
        }
