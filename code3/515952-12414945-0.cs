    public static class OzirNhExtensions
    {
        // Cast method to use in query
        public static TTarget Cast<TTarget>(this Object source)
        {
            return ((TTarget)source);
        }
    }
    class CastHqlGeneratorForMethod : BaseHqlGeneratorForMethod
    {
        public CastHqlGeneratorForMethod()
        {
            this.SupportedMethods = new MethodInfo[] {
                ReflectionHelper.GetMethodDefinition(
                    () => OzirNhExtensions.Cast<Object>(null)
                )
            };
        }
        // In here simply skip cast expression 
        // (it works probably because I have every sub-entity 
        // in the same table that base entity)
        public override HqlTreeNode BuildHql(
            MethodInfo method, 
            Expression targetObject, 
            ReadOnlyCollection<Expression> arguments, 
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor)
        {
            return visitor.Visit(arguments[0]).AsExpression();
        }
    }
