    inputmethod.Statements.Add(new CodeAssignStatement(
        new CodeVariableReferenceExpression("ColA"),
        new CodeArrayIndexerExpression(
            new CodeVariableReferenceExpression("inputs"),
            new CodePrimitiveExpression(0))));
