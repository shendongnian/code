    [TestClass]
    public abstract class SuperHeroTest<TSuperHero>
    {
        protected abstract TSuperHero GetSuperHero();
        [TestMethod]
        public void IfSuperHeroCanFlyMustHaveAuthorizeAttribute()
        {
            var superHero = GetSuperHero();
            if (superHero is IFlyable)
            {
                var superHeroFlyable = superHero;
                var method = typeof (TSuperHero).GetMethod("Fly");
                var hasAttribute = 
                    method.GetCustomAttributes(typeof (AuthorizeAttribute), false).Any();
                Assert.IsTrue(hasAttribute);
            }
        }
        public static MethodInfo MethodOf(Expression<System.Action> expression)
        {
            var body = (MethodCallExpression)expression.Body;
            return body.Method;
        }
        public static bool MethodHasAuthorizeAttribute(Expression<System.Action> expression)
        {
            var method = MethodOf(expression);
            const bool includeInherited = false;
            return method.GetCustomAttributes(
                typeof(AuthorizeAttribute), includeInherited).Any();
        }
    }
