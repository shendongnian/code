    public class Selector<T> : List<ISelectorNode<object>>
    {
        public Selector()
        {
            Add(typeof(T), this);
        }
        void Add(Type type, List<ISelectorNode<object>> nodes)
        {
            foreach (var property in type.GetProperties()) //with whatever flags
            {
                //the second argument is a cool param name I have given, discard-able 
                var paramExpr = Expression.Parameter(type, type.Name[0].ToString().ToLower()); 
                var propExpr = Expression.Property(paramExpr, property);
                
                var innerNode = new SelectorNode(Expression.Lambda(propExpr, paramExpr));
                nodes.Add(innerNode);
                Add(property.PropertyType, innerNode);
            }
        }
    }
    public class SelectorNode : List<ISelectorNode<object>>, ISelectorNode<object>
    {
        internal SelectorNode(LambdaExpression selector)
        {
        }
    }
