    private Expression<Func<TChildEntity, bool>> GetParentWhere<TChildEntity>(
       Expression<Func<TChildEntity, ParentEntity>> parentSelector, 
       string searchText)
    {
       int intSearchText;
       bool isInt = int.TryParse(searchText, out intSearchText);
       
       DateTime dateSearchText;
       bool isDate = DateTime.TryParse(searchText, out dateSearchText);
       
       SubmissionStatus submissionStatus;
       bool isStatus = Enum.TryParse(searchText, true, out submissionStatus);
       
       Expression<Func<ParentEntity, bool>> predicate = parent => 
          parent.CreationUser.Contains(searchText) ||
          ...
       ;
       
       Expression body = ReplacementVisitor.Replace(
          predicate, 
          predicate.Parameters[0], 
          parentSelector.Body);
       
       return Expression.Lambda<Func<TChildEntity, bool>>(body, 
          parentSelector.Parameters[0]);
    }
    
    private sealed class ReplacementVisitor : ExpressionVisitor
    {
      private IList<ParameterExpression> SourceParameters { get; set; }
      private Expression ToFind { get; set; }
      private Expression ToReplace { get; set; }
    
      public static Expression Replace(
          LambdaExpression source, 
          Expression toFind, 
          Expression toReplace)
      {
    	 var visitor = new ReplacementVisitor
    	 {
    		SourceParameters = source.Parameters,
    		ToFind = toFind,
    		ToReplace = toReplace,
    	 };
    
    	 return visitor.Visit(source.Body);
      }
    
      private Expression ReplaceNode(Expression node)
      {
    	 return (node == ToFind) ? ToReplace : node;
      }
    
      protected override Expression VisitParameter(ParameterExpression node)
      {
    	 if (SourceParameters.Contains(node)) return ReplaceNode(node);
    	 return SourceParameters.FirstOrDefault(p => p.Name == node.Name) ?? node;
      }
    }
    
    ...
    
    return crudEngine.Read<ChildEntity>()
        .Include(parameters => parameters.ParentEntity)
        .Where(GetParentWhere<ChildEntity>(child => child.ParentEntity, searchText));
