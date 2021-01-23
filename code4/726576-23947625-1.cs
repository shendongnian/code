    ParameterExpression paramExp = Expression.Parameter(typeof(AnEntity));
    NewExpression newHolder = Expression.New(typeof(Holder));                    
    MemberInfo item1Member = anonType.GetMember("Item1")[0];
    MemberInfo item2Member = anonType.GetMember("Item2")[0];
    MemberInfo item3Member = anonType.GetMember("Item3")[0];
    // Create a MemberBinding object for each member 
    // that you want to initialize.
     MemberBinding item1MemberBinding =
     Expression.Bind(
         item1Member,
         Expression.PropertyOrField(paramExp, "prop1"));
     MemberBinding item2MemberBinding =
     Expression.Bind(
         item2Member,
         Expression.PropertyOrField(paramExp, "prop2"));
     MemberBinding item3MemberBinding =
     Expression.Bind(
         item3Member,
         Expression.PropertyOrField(paramExp, "prop3"));
    // Create a MemberInitExpression that represents initializing 
    // two members of the 'Animal' class.
    MemberInitExpression memberInitExpression =
        Expression.MemberInit(
            newHolder,
            item1MemberBinding,
            item2MemberBinding,
            item3MemberBinding);
    
    var lambda = Expression.Lambda<Func<AnEntity, Holder>>(memberInitExpression, paramExp);
