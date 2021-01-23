		public static class DataServiceContextExtensions
		{
			public static void AddOrAttachLink<TSource>(this DataServiceContext context, object source, Expression<Func<TSource>> sourceProperty, object target)
			{
				AddOrAttachLink(context, source, sourceProperty.GetExpressionMemberInfo().Name, target);
			}
			public static void AddOrAttachLink<TSource, TTarget>(this DataServiceContext context, TSource source, Expression<Func<TSource, ICollection<TTarget>>> sourceProperty, TTarget target)
			{
				AddOrAttachLink(context, source, sourceProperty.GetExpressionMemberInfo().Name, target);
			}
			public static void AddOrAttachLink(this DataServiceContext context, object source, string propertyName, object target)
			{
				var descriptor = context.GetLinkDescriptor(source, propertyName, target);
				if(descriptor == null)
				{
					context.AddLink(source, propertyName, target);
				}
				else if(descriptor.State == EntityStates.Deleted)
				{
					context.DetachLink(source, propertyName, target);
					context.AttachLink(source, propertyName, target);
				}
			}
			public static void DeleteOrDetachLink<TSource>(this DataServiceContext context, object source, Expression<Func<TSource>> sourceProperty, object target)
			{
				DeleteOrDetachLink(context, source, sourceProperty.GetExpressionMemberInfo().Name, target);
			}
			public static void DeleteOrDetachLink<TSource, TTarget>(this DataServiceContext context, TSource source, Expression<Func<TSource, ICollection<TTarget>>> sourceProperty, TTarget target)
			{
				DeleteOrDetachLink(context, source, sourceProperty.GetExpressionMemberInfo().Name, target);
			}
			public static void DeleteOrDetachLink(this DataServiceContext context, object source, string propertyName, object target)
			{
				var descriptor = context.GetLinkDescriptor(source, propertyName, target);
				if(descriptor == null)
				{
					context.AttachLink(source, propertyName, target);
					context.DeleteLink(source, propertyName, target);
				}
				else if(descriptor.State == EntityStates.Added)
				{
					context.DetachLink(source, propertyName, target);
				}
				else
				{
					context.DeleteLink(source, propertyName, target);
				}
			}
			public static MemberInfo GetExpressionMemberInfo(this Expression expression)
			{
				var lambda = (LambdaExpression)expression;
				MemberExpression memberExpression;
				if(lambda.Body is UnaryExpression)
				{
					var unaryExpression = (UnaryExpression)lambda.Body;
					memberExpression = (MemberExpression)unaryExpression.Operand;
				}
				else
				{
					memberExpression = (MemberExpression)lambda.Body;
				}
				return memberExpression.Member;
			}
		}
