    SomeDto dto = null;
    Assignee assignee = null;
    session.QueryOver<Task>()
        .JoinAlias(task => task.Assignee, () => assignee)
        .OrderBy(() => assignee.Status)
        .SelectList(list => list
            .Select(task => task.Name).WithAlias(() => dto.Name)
            .Select(() => assignee.Name).WithAlias(() => dto.Assignee)
            .Select(task => assignee.Status).WithAlias(() => dto.Status))
        .TransformUsing(Transformers.AliasToBean<SomeDto>())
        .List<SomeDto>()
