    Une erreur inattendue de type InvalidOperationException s'est produite sur le serveur
    System.InvalidOperationException: Code supposed to be unreachable
       à System.Linq.Expressions.Compiler.StackSpiller.RewriteExpression(Expression node, Stack stack)
       à System.Linq.Expressions.Compiler.StackSpiller.RewriteUnaryExpression(Expression expr, Stack stack)
       à System.Linq.Expressions.Compiler.StackSpiller.RewriteExpression(Expression node, Stack stack)
       à System.Linq.Expressions.Compiler.StackSpiller.RewriteExpressionFreeTemps(Expression expression, Stack stack)
       à System.Linq.Expressions.Compiler.StackSpiller.Rewrite[T](Expression`1 lambda)
       à System.Linq.Expressions.Expression`1.Accept(StackSpiller spiller)
       à System.Linq.Expressions.Compiler.LambdaCompiler.Compile(LambdaExpression lambda, DebugInfoGenerator debugInfoGenerator)
       à System.Linq.Expressions.Expression`1.Compile()
       à NHibernate.Linq.ExpressionToHqlTranslationResults.MergeLambdasAndCompile[TDelegate](IList`1 itemTransformers)
       à NHibernate.Linq.ExpressionToHqlTranslationResults..ctor(HqlTreeNode statement, IList`1 itemTransformers, IList`1 listTransformers, IList`1 postExecuteTransformers, List`1 additionalCriteria)
       à NHibernate.Linq.IntermediateHqlTree.GetTranslation()
       à NHibernate.Linq.Visitors.QueryModelVisitor.GenerateHqlQuery(QueryModel queryModel, VisitorParameters parameters, Boolean root)
       à NHibernate.Linq.NhLinqExpression.Translate(ISessionFactoryImplementor sessionFactory, Boolean filter)
       à NHibernate.Hql.Ast.ANTLR.ASTQueryTranslatorFactory.CreateQueryTranslators(IQueryExpression queryExpression, String collectionRole, Boolean shallow, IDictionary`2 filters, ISessionFactoryImplementor factory)
       à NHibernate.Engine.Query.QueryExpressionPlan.CreateTranslators(IQueryExpression queryExpression, String collectionRole, Boolean shallow, IDictionary`2 enabledFilters, ISessionFactoryImplementor factory)
       à NHibernate.Engine.Query.QueryExpressionPlan..ctor(IQueryExpression queryExpression, Boolean shallow, IDictionary`2 enabledFilters, ISessionFactoryImplementor factory)
       à NHibernate.Engine.Query.QueryPlanCache.GetHQLQueryPlan(IQueryExpression queryExpression, Boolean shallow, IDictionary`2 enabledFilters)
       à NHibernate.Impl.AbstractSessionImpl.GetHQLQueryPlan(IQueryExpression queryExpression, Boolean shallow)
       à NHibernate.Impl.AbstractSessionImpl.CreateQuery(IQueryExpression queryExpression)
       à NHibernate.Linq.DefaultQueryProvider.PrepareQuery(Expression expression, IQuery& query, NhLinqExpression& nhQuery)
       à NHibernate.Linq.DefaultQueryProvider.Execute(Expression expression)
       à NHibernate.Linq.DefaultQueryProvider.Execute[TResult](Expression expression)
       à System.Linq.Queryable.Sum[TSource](IQueryable`1 source, Expression`1 selector)
       à Secib.Server.Services.ReglementService.GetRegleTtc(FactureView facture) dans x:\Sources\Next\Alpha\SecibNext\Secib.Server\Services\ReglementService.cs:ligne 425
       à Secib.Server.Services.ReglementService.DoesMontantSoldeFacture(FactureView facture, Decimal montantImpute) dans x:\Sources\Next\Alpha\SecibNext\Secib.Server\Services\ReglementService.cs:ligne 391
       à Secib.Server.Services.ReglementService.DispatcheMontantImpute(Reglement reglement, ReglementFactureCompactDto factureDto) dans x:\Sources\Next\Alpha\SecibNext\Secib.Server\Services\ReglementService.cs:ligne 236
       à Secib.Server.Services.ReglementService.SaveReglement(Reglement reglement, IList`1 factures) dans x:\Sources\Next\Alpha\SecibNext\Secib.Server\Services\ReglementService.cs:ligne 197
       à Secib.Server.Controllers.ReglementController.<SaveReglement>z__OriginalMethod() dans x:\Sources\Next\Alpha\SecibNext\Secib.Server\Controllers\ReglementController.cs:ligne 141
       à Secib.Server.Controllers.ReglementController.<SaveReglement>c__Binding.Invoke(Object& instance, Arguments arguments, Object aspectArgs) dans :ligne 0
       à PostSharp.Aspects.Internals.MethodInterceptionArgsImpl`1.Proceed()
       à Secib.Server.Aspects.TransactionAspect.OnInvoke(MethodInterceptionArgs args) dans x:\Sources\Next\Alpha\SecibNext\Secib.Server\Aspects\TransactionAspect.cs:ligne 32
