    public class LogicalOperatorRewriter : SyntaxRewriter
    {
        public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            SyntaxKind newExpressionKind = GetNewKind(node.Kind);
            BinaryExpressionSyntax newNode = (BinaryExpressionSyntax)Syntax.BinaryExpression(newExpressionKind, left: node.Left, right: node.Right).Format().GetFormattedRoot();
            return base.VisitBinaryExpression(newNode);
        }
        private SyntaxKind GetNewKind(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.LogicalAndExpression:
                    return SyntaxKind.LogicalOrExpression;
                case SyntaxKind.LogicalOrExpression:
                    return SyntaxKind.LogicalAndExpression;
                default: return kind;
            }
        }
    }
