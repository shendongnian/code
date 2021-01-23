    public class ContainsValueGenerator : BaseHqlGeneratorForMethod
    {
        public ContainsValueGenerator()
        {
            SupportedMethods = new[] { ReflectionHelper.GetMethodDefinition(() => new Dictionary<object, object>().ContainsValue(null)) };
        }
        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.In(visitor.Visit(arguments[0]).AsExpression(), treeBuilder.Elements(visitor.Visit(targetObject).AsExpression()));
        }
    }
