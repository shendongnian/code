    public class ExpressionMapper<TTarget> : ExpressionVisitor
    {
        protected ExpressionMapper(Type sourceType, Func<string, string> resolveTargetMemberNameFunc)
        {
            this.SourceType = sourceType;
            this.ResolveTargetMemberNameFunc = resolveTargetMemberNameFunc ?? (cur => cur);
        }
        public Func<string, string> ResolveTargetMemberNameFunc { get; private set; }
        public Type SourceType { get; private set; }
        public static Expression MapFrom<TSource>(Expression sourceExpression, Func<string, string> resolveTargetMemberNameFunc)
        {
            return new ExpressionMapper<TTarget>(typeof(TSource), resolveTargetMemberNameFunc).Visit(sourceExpression);
        }
        public static Expression<Func<TTarget, bool>> MapFrom<TSource>(Expression<Func<TSource, bool>> sourcePredicateExpression, Func<string, string> resolveTargetMemberNameFunc)
        {
            return Expression.Lambda<Func<TTarget, bool>>(
                    MapFrom<TSource>(sourcePredicateExpression.Body, resolveTargetMemberNameFunc),
                    Expression.Parameter(typeof(TTarget), sourcePredicateExpression.Parameters[0].Name));
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            var sourceMemberName = node.Member.Name;
            var targetNode = this.Visit(node.Expression);
            var targetMemberName = this.ResolveTargetMemberNameFunc(sourceMemberName);
            var targetMember = targetNode.Type.GetMember(targetMemberName).FirstOrDefault();
            if (targetMember == null)
            {
                throw new NotSupportedException(String.Format("The source type '{0}' cannot be mapped to the target type '{1}', because that target type has no member '{2}'.", node.Expression.Type.Name, targetNode.Type.Name, targetMemberName));
            }
            return Expression.MakeMemberAccess(targetNode, targetMember);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == this.SourceType)
            {
                return Expression.Parameter(typeof(TTarget), node.Name);
            }
            return node;
        }
    }
