	public class SomeClass
	{
		private static MethodInfo methodOf_CreateLambdaGeneric = 
			typeof(SomeClass).GetMethod("CreateIsActiveLambdaGeneric");
		public static Expression<Func<T, bool>> CreateIsActiveLambdaGeneric<T>() where T : BaseEntity {
			return x => x.IsActive;
		}
		public static LambdaExpression CreateIsActiveLambda(Type type) {
			MethodInfo particularized = methodOf_CreateLambdaGeneric.MakeGenericMethod(type);
			object theLambda = particularized.Invoke(null, null);
			return theLambda as LambdaExpression;
		}
        }
