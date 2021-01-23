    var selector = QueryHelper.ToPredicate<Category>("theColumn", "hello");
    return this.ObjectContext.Categories.Where(selector);     
    
    LoadOperation<Employee> loader = context.Load( context.GetEmployeesQuery()
                                            .Where( selector ) );
    loader.Completed += (op) =>
      {
        if ( !op.HasErrors)
        {
        }
      };
