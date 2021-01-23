    [ExportSyntaxNodeCodeIssueProvider("PropertyExpressionCodeIssue", LanguageNames.CSharp, typeof(InvocationExpressionSyntax))]
    class PropertyExpressionCodeIssueProvider : ICodeIssueProvider
    {
        [ImportingConstructor]
        public PropertyExpressionCodeIssueProvider()
        {}
        public IEnumerable<CodeIssue> GetIssues(IDocument document, CommonSyntaxNode node, CancellationToken cancellationToken)
        {
            var invocation = (InvocationExpressionSyntax)node;
            var semanticModel = document.GetSemanticModel(cancellationToken);
            var semanticInfo = semanticModel.GetSemanticInfo(invocation, cancellationToken);
            var methodSymbol = (MethodSymbol)semanticInfo.Symbol;
            if (methodSymbol == null)
                yield break;
            var attributes = methodSymbol.GetAttributes();
            if (!attributes.Any(a => a.AttributeClass.Name == "PropertyExpressionAttribute"))
                yield break;
            var arguments = invocation.ArgumentList.Arguments;
            foreach (var argument in arguments)
            {
                var lambdaExpression = argument.Expression as SimpleLambdaExpressionSyntax;
                if (lambdaExpression == null)
                    continue;
                var parameter = lambdaExpression.Parameter;
                var memberAccess = lambdaExpression.Body as MemberAccessExpressionSyntax;
                if (memberAccess != null)
                {
                    var objectIdentifierSyntax = memberAccess.Expression as IdentifierNameSyntax;
                    if (objectIdentifierSyntax != null
                        && objectIdentifierSyntax.PlainName == parameter.Identifier.ValueText
                        && semanticModel.GetSemanticInfo(memberAccess, cancellationToken).Symbol is PropertySymbol)
                        continue;
                }
                yield return
                    new CodeIssue(
                        CodeIssue.Severity.Error, argument.Span,
                        string.Format("Has to be simple property access of '{0}'", parameter.Identifier.ValueText));
            }
        }
        #region Unimplemented ICodeIssueProvider members
        public IEnumerable<CodeIssue> GetIssues(IDocument document, CommonSyntaxToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<CodeIssue> GetIssues(IDocument document, CommonSyntaxTrivia trivia, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
