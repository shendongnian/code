    public interface IHaveParentEntity
    {
       ParentEntity ParentEntity { get; }
    }
    
    private Expression<Func<TChildEntity, bool>> GetParentWhere<TChildEntity>(string searchText) 
       where TChildEntity : IHaveParentEntity
    {
       int intSearchText;
       bool isInt = int.TryParse(searchText, out intSearchText);
       
       DateTime dateSearchText;
       bool isDate = DateTime.TryParse(searchText, out dateSearchText);
       
       SubmissionStatus submissionStatus;
       bool isStatus = Enum.TryParse(searchText, true, out submissionStatus);
       
       return child => 
          child.ParentEntity.CreationUser.Contains(searchText) ||
          ...
       ;
    }
    
    ...
    
    return crudEngine.Read<ChildEntity>()
        .Include(parameters => parameters.ParentEntity)
        .Where(GetParentWhere<ChildEntity>(searchText));
