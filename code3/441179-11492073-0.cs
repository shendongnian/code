    // Below SyntaxRewriter removes multiple assignement statements from under the 
    // SyntaxNode being visited.
    public class AssignmentStatementRemover : SyntaxRewriter
    {
        public override SyntaxNode VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            SyntaxNode updatedNode = base.VisitExpressionStatement(node);
            if (node.Expression.Kind == SyntaxKind.AssignExpression)
            {
                if (node.Parent.Kind == SyntaxKind.Block)
                {
                    // There is a parent block so it is ok to remove the statement completely.
                    updatedNode = null;
                }
                else
                {
                    // The parent context is some statement like an if statement without a block.
                    // Return an empty statement.
                    updatedNode = Syntax.EmptyStatement()
                        .WithLeadingTrivia(updatedNode.GetLeadingTrivia())
                        .WithTrailingTrivia(updatedNode.GetTrailingTrivia());
                }
            }
         return updatedNode;
        }
    }
