    var interfaceType = typeof(IArticleManager);
    var targetType = typeof(SqlArticle);
    foreach(var member in interfaceType.GetMembers())
    {
        var targetMember = targetType.GetMember(member.Name);
        // compare the arguments, generic constraints, etc here
    }
