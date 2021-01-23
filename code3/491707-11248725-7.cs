    [TestFixture]
    public class RemappingTests
    {
        #region Setup/Teardown
        /// <summary>
        /// Sets up the variables before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var accountModelMap = Mapper.CreateMap<AccountModel, Account>();
            Contract.Assume(accountModelMap != null);
            accountModelMap.ForMember(account => account.Id, expression => expression.MapFrom(model => model.Id));
            accountModelMap.ForMember(account => account.Balance, expression => expression.MapFrom(model => model.Bal));
            accountModelMap.ForMember(account => account.CustomerName, expression => expression.MapFrom(model => model.Name));
        }
        
        [TearDown]
        public void Teardown()
        {
            Mapper.Reset();
        }
        #endregion
        /// <summary>
        /// Checks that <see cref="ExpressionExtensions.RemapForType{TSource, TDestination, TResult}(Expression{Func{TSource, TResult}})"/> correctly remaps all property access for the new type.
        /// </summary>
        /// <param name="balance">The balance to use as the value for <see cref="Account.Balance"/>.</param>
        /// <returns>Whether the <see cref="Account.Balance"/> was greater than 50.</returns>
        [TestCase(0, Result = false)]
        [TestCase(80, Result = true)]
        public bool RemapperUsesPropertiesOfNewDataType(double balance)
        {
            Expression<Func<AccountModel, bool>> modelExpr = model => model.Bal > 50;
            
            var accountExpr = modelExpr.RemapForType<AccountModel, Account, bool>();
            
            var compiled = accountExpr.Compile();
            Contract.Assume(compiled != null);
            
            var hasBalance = compiled(new Account {Balance = balance});
            
            return hasBalance;
        }
    }
